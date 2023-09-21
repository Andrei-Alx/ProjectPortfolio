using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
	public class OrderManager
	{
		private List<Order> orders;
		private Dictionary<string, int> OrdersPerTime;
		private IDbOrderHelper iDbOrderHelper = new DbOrderHelper();

		public OrderManager(IDbOrderHelper IdbOrderHelper)
		{
			this.iDbOrderHelper = iDbOrderHelper
				?? throw new ArgumentNullException(nameof(iDbOrderHelper));
			orders = new List<Order>();
			OrdersPerTime = new Dictionary<string, int>();
			OrdersPerTime = IdbOrderHelper.GetOrdersPerTimeSlot();
		}
		public List<Order> GetAllOrders()
		{
			List<Order> products = new List<Order>();
			foreach (OrderDTO orderDTO in iDbOrderHelper.GetOrders())
			{
				Order order = new Order(orderDTO);
				orders.Add(order);
			}
			return products;
		}

		public bool IsAvailableTimeslot(string time)
		{
			foreach (KeyValuePair<string, int> keyValuePair in OrdersPerTime)
			{
				if (keyValuePair.Key == time)
				{
					if (keyValuePair.Value >= 5)
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool AddOrder(User customer, List<Product> boughtItems, decimal totalPrice, HomeDelivery? homeDelivery, PickupDelivery? pickupDelivery, string status, string orderTime)
		{
			try
			{
				UserDTO u = new UserDTO(customer.Name, customer.GetType(customer.Role));
				u.Id = customer.Id;
				List<ProductDTO> productDTOs = new List<ProductDTO>();
				foreach (Product p in boughtItems)
				{
					CategoryDTO categoryDTO = new CategoryDTO(p.Category.Name, null);
					CategoryDTO subcategoryDTO = new CategoryDTO(p.SubCategory.Name, p.SubCategory.ParentId);
					ProductDTO pd = new ProductDTO(p.Id, p.Name, p.Price, categoryDTO, subcategoryDTO, p.GetTypeStatus(p.ProductStatus), p.GetTypeUnit(p.Unit), p.Image);
					pd.Id = p.Id;
					productDTOs.Add(pd);
				}

				if (customer != null && IsAvailableTimeslot(orderTime))
				{
					if (pickupDelivery == null)
					{
						HomeDeliveryDTO HDDTO = new HomeDeliveryDTO(homeDelivery.Fullname, homeDelivery.Email, homeDelivery.Adress);
						iDbOrderHelper.CreateOrder(u, productDTOs, totalPrice, status, HDDTO, null, orderTime);
						orders.Add(new Order(customer, boughtItems, totalPrice, homeDelivery, status, orderTime));
						return true;
					}
					else if (homeDelivery == null)
					{
						PickupDeliveryDTO PUDTO = new PickupDeliveryDTO(pickupDelivery.Fullname, pickupDelivery.Email, pickupDelivery.Store);
						iDbOrderHelper.CreateOrder(u, productDTOs, totalPrice, status, null, PUDTO, orderTime);
						orders.Add(new Order(customer, boughtItems, totalPrice, pickupDelivery, status, orderTime));
						return true;
					}
				}
				else
				{
					throw new Exception("Order could not be created.");
				}
				return false;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Order GetOrder(int id)
		{
			Order product = new Order(iDbOrderHelper.GetOrderByID(id));
			return product;
		}

		public bool UpdateOrderStatus(int id, string status)
		{
			try
			{
				if (status != String.Empty && Enum.TryParse<OrderStatus>(status, out OrderStatus orderStatus) == true)
				{
					iDbOrderHelper.UpdateStatus(id, status);
					return true;
				}
				else
				{
					throw new Exception("Status could not be updated.");
				}
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}
	}
}
