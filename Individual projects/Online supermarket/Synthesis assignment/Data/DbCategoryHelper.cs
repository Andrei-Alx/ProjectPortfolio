using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DbCategoryHelper : DbHelper, IDbCategoryHelper
    {
        public void CreateCategory(string name, int? parent)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                if (parent != null)
                {
                    string sql = @"INSERT INTO SynCategory([name], parentid)
                                            VALUES(@Name,@id);";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("id", parent);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            List<CategoryDTO> categories = new List<CategoryDTO>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"SELECT * 
                               FROM SynCategory
                               WHERE parentid is null";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                CategoryDTO? category = null;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    category = new CategoryDTO();
                    category.Id = dr.GetInt32("Id");
                    category.Name = dr.GetString("Name");

                    categories.Add(category);
                }
                conn.Close();
                return categories;
            }
        }
        public List<CategoryDTO> GetSubCategories(int id)
        {
            List<CategoryDTO> categories = new List<CategoryDTO>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @" SELECT sc.id, sc1.[name]
                                FROM SynCategory sc
                                JOIN SynCategory sc1
                                ON sc.id = sc1.parentid
                                WHERE sc.Id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                conn.Open();

                CategoryDTO? category = null;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    category = new CategoryDTO();
                    category.Id = dr.GetInt32("id");
                    category.Name = dr.GetString("name");

                    categories.Add(category);
                }
                conn.Close();
                return categories;
            }
        }
        public void UpdateCategory(CategoryDTO category)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "UPDATE SynCategory SET [name]=@Name WHERE id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", category.Id);
                cmd.Parameters.AddWithValue("name", category.Name);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void UpdateSubCategory(CategoryDTO category)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "UPDATE SynCategory SET [name]=@Name, parentid = @ParentID WHERE id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", category.Id);
                cmd.Parameters.AddWithValue("name", category.Name);
                cmd.Parameters.AddWithValue("parentid", category.ParentId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public CategoryDTO GetCategoryByName(string Name)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"  SELECT * 
                                 FROM SynCategory
                                 WHERE [name] = @name";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("name", Name);

                CategoryDTO category = null;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    category = new CategoryDTO();
                    category.Id = dr.GetInt32("id");
                    category.Name = Name;
                    category.ParentId = dr.IsDBNull("parentid") ? null : dr.GetInt32("parentid");

                }
                return category;
            }
        }
        public void DeleteCategory(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"DELETE from SynCategory
                                WHERE id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
