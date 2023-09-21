using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Data
{
    public class DbProductHelper : DbHelper, IDbProductHelper
    {
        DbCategoryHelper dbCategoryHelper= new DbCategoryHelper();

        public void AddProduct(string category, string subCategory, string status, string name, decimal price, string unit, string? image)
        {
            //bool isValid;
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = @"INSERT INTO SynProducts(name,
                                                    price,
                                                    subCategory,
                                                    category,
                                                    [status],
                                                    unit,
                                                    image)
                                            VALUES(@name,
                                                    @price,
                                                    @subCategory,
                                                    @category,
                                                    @unit,
                                                    @image);";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("price", price);
                    cmd.Parameters.AddWithValue("subCategory", subCategory);
                    cmd.Parameters.AddWithValue("category", category);
                    cmd.Parameters.AddWithValue("status", status);
                    cmd.Parameters.AddWithValue("unit", unit);
                    cmd.Parameters.AddWithValue("image", image);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //isValid = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //return isValid;
        }

		public IEnumerable<ProductDTO> GetAvailableProducts()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connStr))
				{
					string sql = @"SELECT * 
                                   FROM SynProducts 
                                   WHERE status = 'Available'";
					SqlCommand cmd = new SqlCommand(sql, conn);
					conn.Open();

					SqlDataReader dr = cmd.ExecuteReader();

					ProductDTO product = new ProductDTO();
					List<ProductDTO> productDTOs = new List<ProductDTO>();
					while (dr.Read())
					{
						product = new ProductDTO();
						product.Id = dr.GetInt32("id");
						product.Name = dr.GetString("name");
						product.Category = dbCategoryHelper.GetCategoryByName(dr.GetString("category"));
						if (dr.IsDBNull("subCategory")) { product.SubCategory = null; }
						else { product.SubCategory = dbCategoryHelper.GetCategoryByName(dr.GetString("subCategory")); }
						product.ProductStatus = dr.GetString("status");
						product.Price = dr.GetDecimal("price");
						product.MeasureUnit = dr.GetString("unit");
						product.Image = dr.GetString("image");
						productDTOs.Add(product);
					}
					return productDTOs;
				}
			}
			catch (Exception ex)
			{
				throw new ArgumentException(ex.ToString());
			}
		}

		public IEnumerable<ProductDTO> GetProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = @"SELECT * FROM SynProducts";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    ProductDTO product = new ProductDTO();
                    List<ProductDTO> productDTOs = new List<ProductDTO>();
                    while (dr.Read())
                    {
                        product = new ProductDTO();
                        product.Id = dr.GetInt32("id");
                        product.Name = dr.GetString("name");
                        product.Category = dbCategoryHelper.GetCategoryByName(dr.GetString("category"));
                        if(dr.IsDBNull("subCategory")) { product.SubCategory = null; }
                        else { product.SubCategory = dbCategoryHelper.GetCategoryByName(dr.GetString("subCategory")); }
                        product.ProductStatus = dr.GetString("status");
                        product.Price = dr.GetDecimal("price");
                        product.MeasureUnit = dr.GetString("unit");
                        product.Image = dr.GetString("image");
                        productDTOs.Add(product);
                    }
                    return productDTOs;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
        }

		public IEnumerable<ProductDTO> GetProductsBySubCategory(string subCategoryName)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connStr))
				{
					string sql = @"SELECT id, [name], category ,subCategory, [status], price, unit, image
                                FROM SynProducts
                                WHERE subCategory = @subCategoryName";
					SqlCommand cmd = new SqlCommand(sql, conn);
					cmd.Parameters.AddWithValue("subCategoryName", subCategoryName);

					conn.Open();

					SqlDataReader dr = cmd.ExecuteReader();

					ProductDTO product = new ProductDTO();
					List<ProductDTO> productDTOs = new List<ProductDTO>();
					while (dr.Read())
					{
						product = new ProductDTO();
						product.Id = dr.GetInt32("id");
						product.Name = dr.GetString("name");
						product.Category = dbCategoryHelper.GetCategoryByName(dr.GetString("category"));
						if (dr.IsDBNull("subCategory")) { product.SubCategory = null; }
						else { product.SubCategory = dbCategoryHelper.GetCategoryByName(dr.GetString("subCategory")); }
						product.ProductStatus = dr.GetString("status");
						product.Price = dr.GetDecimal("price");
						product.MeasureUnit = dr.GetString("unit");
						product.Image = dr.GetString("image");
						productDTOs.Add(product);
					}
					return productDTOs;
				}
			}
			catch (Exception ex)
			{
				throw new ArgumentException(ex.ToString());
			}
		}

		public void UpdateProduct(int id, string category, string subCategory, string status, string name, decimal price, string unit, string? image)
        {
            //bool isValid;
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = @"UPDATE SynProducts SET name = @name, price = @price, category = @category, status = @status, unit = @unit, image = @image WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@subCategory", subCategory);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@unit", unit);
                    cmd.Parameters.AddWithValue("@image", image);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //isValid = true;
                }
            }
            catch (Exception ex)
            {
				throw new Exception(ex.Message);
				//isValid = false;
			}
            //return isValid;
        }

        public ProductDTO? GetProductByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"SELECT * FROM SynProducts WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", id);

                ProductDTO? product = null;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    product = new ProductDTO();
                    product.Id = id;
                    product.Name = dr.GetString("name");
                    product.Category = dbCategoryHelper.GetCategoryByName(dr.GetString("category"));
                    if (dr.IsDBNull("subCategory")) { product.SubCategory = null; }
                    else { product.SubCategory = dbCategoryHelper.GetCategoryByName(dr.GetString("subCategory")); }
                    product.Price = dr.GetDecimal("price");
                    product.ProductStatus = dr.GetString("status");
                    product.MeasureUnit = dr.GetString("unit");
                    product.Image = dr.GetString("image");
                }
                return product;
            }
        }

   //     public void DeleteProduct(int id)
   //     {
   //         //bool isValid;
   //         try
   //         {
   //             using (SqlConnection conn = new SqlConnection(connStr))
   //             {
   //                 conn.Open();
   //                 string sql = @"DELETE FROM SynProducts WHERE id = @id";
   //                 SqlCommand cmd = new SqlCommand(sql, conn);
   //                 cmd.Parameters.AddWithValue("@id", id);
   //                 cmd.ExecuteNonQuery();
   //                 //isValid = true;
   //             }
   //         }
   //         catch (Exception ex)
   //         {
			//	throw new Exception(ex.Message);
			//	//isValid = false;
			//}
   //         //return isValid;
   //     }

        public void ModifyProductStatus(int id, string status)
        {
            //bool isValid;
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = @"UPDATE SynProducts SET status = @status WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@status", status);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //isValid = true;
                }
            }
            catch (Exception ex)
            {
				throw new Exception(ex.Message);
				//isValid = false;
            }
            //return isValid;
        }
    }
}