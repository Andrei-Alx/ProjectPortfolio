using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace Data
{
	public class DbOrderHelper : DbHelper, IDbOrderHelper
	{
		public DbOrderHelper()
		{

		}
		public List<OrderDTO> GetOrders()
		{
			List<OrderDTO> orders = new List<OrderDTO>();
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				string sql = @"SELECT *
                               FROM SynOrder";

				SqlCommand cmd = new SqlCommand(sql, conn);
				conn.Open();

				OrderDTO? orderDTO = null;
				SqlDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					orderDTO = new OrderDTO();
					orderDTO.Id = dr.GetInt32("id");
					orderDTO.OrderTime = dr.GetString("time");
					orderDTO.Products = GetOrderProducts(orderDTO.Id);
					orderDTO.Status = dr.GetString("status");
					orderDTO.Total = dr.GetDecimal("total");
					orders.Add(orderDTO);
				}
				conn.Close();
				return orders;
			}
		}

		public void UpdateStatus(int id, string newStatus)
		{
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				string sql = "UPDATE SynOrder SET status=@status WHERE id=@id";
				SqlCommand cmd = new SqlCommand(sql, conn);

				cmd.Parameters.AddWithValue("id", id);
				cmd.Parameters.AddWithValue("status", newStatus);

				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();
			}
		}

		public Dictionary<string, int> GetOrdersPerTimeSlot()
		{
			Dictionary<string, int> ordersPerTimeSlot = new Dictionary<string, int>();
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				string sql = @"SELECT [time], count([time]) AS OrderCount
                                        FROM [SynOrder]
                                        GROUP BY [time]";
				SqlCommand cmd = new SqlCommand(sql, conn);
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					string orderTime = reader.GetString("time");
					int orderCount = reader.GetInt32("OrderCount");
					ordersPerTimeSlot.Add(orderTime, orderCount);
				}
				return ordersPerTimeSlot;
			}
		}

		public OrderDTO GetOrderByID(int id)
		{
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				string sql = "SELECT * FROM SynOrder WHERE id = @id";
				SqlCommand cmd = new SqlCommand(sql, conn);

				cmd.Parameters.AddWithValue("id", id);

				OrderDTO? orderDTO = null;
				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();


				while (dr.Read())
				{
					orderDTO = new OrderDTO();
					orderDTO.Id = dr.GetInt32("id");
					orderDTO.OrderTime = dr.GetString("time");
					orderDTO.Status = dr.GetString("status");
					orderDTO.Total = dr.GetInt32("total");

				}
				conn.Close();
				return orderDTO;
			}
		}

		public void CreateOrder(UserDTO customer, List<ProductDTO> boughtItems, decimal totalPrice, string status, HomeDeliveryDTO? homeDeliveryDTO, PickupDeliveryDTO? pickupDeliveryDTO, string orderTime)
		{
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				string sql = @"INSERT INTO SynOrder(status, total, time, userId, username, email, adress, store)
                                            VALUES(@status, @total, @time, @userId, @username, @email, @adress, @store)";
				SqlCommand command = new SqlCommand(sql, conn);
				if (pickupDeliveryDTO == null)
				{
					command.Parameters.AddWithValue("total", totalPrice);
					command.Parameters.AddWithValue("username", homeDeliveryDTO.Fullname);
					command.Parameters.AddWithValue("email", homeDeliveryDTO.Email);
					command.Parameters.AddWithValue("adress", homeDeliveryDTO.Adress);
					command.Parameters.AddWithValue("store", DBNull.Value);
					command.Parameters.AddWithValue("time", orderTime);
					command.Parameters.AddWithValue("userId", customer.Id);
					command.Parameters.AddWithValue("status", status);
				}
				else if (homeDeliveryDTO == null)
				{
					command.Parameters.AddWithValue("total", totalPrice);
					command.Parameters.AddWithValue("username", pickupDeliveryDTO.Fullname);
					command.Parameters.AddWithValue("email", pickupDeliveryDTO.Email);
					command.Parameters.AddWithValue("adress", DBNull.Value);
					command.Parameters.AddWithValue("store", pickupDeliveryDTO.Store);
					command.Parameters.AddWithValue("time", orderTime);
					command.Parameters.AddWithValue("userId", customer.Id);
					command.Parameters.AddWithValue("status", status);
				}

				conn.Open();
				command.ExecuteNonQuery();
				conn.Close();
			}
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				foreach (ProductDTO p in boughtItems)
				{
					string sql = @"INSERT INTO SynOrderProduct(
                                                    orderId,
                                                    productId,
                                                    price)
                                            VALUES(@orderID,
                                                    @productID,
                                                    @Price);";

					SqlCommand cmd = new SqlCommand(sql, conn);
					cmd.Parameters.AddWithValue("orderID", GetLastOrderID());
					cmd.Parameters.AddWithValue("productID", p.Id);
					cmd.Parameters.AddWithValue("Price", p.Price);

					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}

			}
		}
		public int GetLastOrderID()
		{
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				string sql = "SELECT TOP 1 id FROM SynOrder ORDER BY id DESC";
				SqlCommand cmd = new SqlCommand(sql, conn);
				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();

				int id = 0;
				while (dr.Read())
				{
					id = dr.GetInt32("id");
				}
				conn.Close();
				return id;
			}
		}
		public List<OrderProductDTO> GetOrderProducts(int orderId)
		{
			IDbCategoryHelper dbCategoryHelper = new DbCategoryHelper();

			List<OrderProductDTO> products = new List<OrderProductDTO>();
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				string sql = @"  SELECT pr.id, op.orderId, pr.name, pr.price, pr.subCategory, pr.category, pr.status, pr.unit, pr.image, op.Price
                                FROM SynProducts as pr
                                INNER JOIN SynOrderProduct as op
                                on pr.id = op.productId
                                WHERE op.orderId = @orderId
                                ORDER BY pr.id";

				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.AddWithValue("orderId", orderId);
				conn.Open();

				OrderProductDTO? orderProduct = null;
				SqlDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					orderProduct = new OrderProductDTO();
					ProductDTO product = new ProductDTO();
					product.Id = dr.GetInt32("pr.id");
					product.Name = dr.GetString("pr.name");
					product.Category = dbCategoryHelper.GetCategoryByName(dr.GetString("pr.category"));
					product.SubCategory = dbCategoryHelper.GetCategoryByName(dr.GetString("pr.subCategory"));
					product.Price = dr.GetDecimal("pr.price");
					product.ProductStatus = dr.GetString("pr.status");
					product.MeasureUnit = dr.GetString("pr.unit");
					product.Image = dr.GetString("ProductImage");
					orderProduct.Product = product;
					orderProduct.Price = dr.GetDecimal("op.Price");
					products.Add(orderProduct);
				}
				return products;
			}
		}
	}
}
