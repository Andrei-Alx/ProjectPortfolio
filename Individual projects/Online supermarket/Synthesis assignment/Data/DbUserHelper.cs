using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DbUserHelper : DbHelper, IDbUserHelper
    {
        public DbUserHelper()
        {

        }

        public IEnumerable<UserDTO> GetUsers()
        {
            List<UserDTO> users = new List<UserDTO>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"SELECT id, name, role
                                FROM SynUsers
                                ORDER BY id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                UserDTO? user = null;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    user = new UserDTO();
                    user.Id = dr.GetInt32("id");
                    user.Name = dr.GetString("name");
                    user.Role = dr.GetString("role");
                    users.Add(user);
                }
                conn.Close();
                return users;
            }
        }

        public UserDTO? FindUser(string name, string password)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"SELECT id, name, role
                               FROM SynUsers
                               WHERE name = @name 
                               AND password = hashbytes('SHA2_256', convert(varchar(max), concat(convert(varchar(max), @password), salt)))";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();
                UserDTO? user = null;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    user = new UserDTO();
                    user.Name = dr.GetString("name");
                    user.Id = dr.GetInt32("id");
                    user.Role = dr.GetString("role");
                }
                conn.Close();
                return user;
            }
        }

		public UserDTO? FindUser(string name)
		{
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				string sql = @"SELECT id, name, role
                               FROM SynUsers
                               WHERE name = @name";

				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.AddWithValue("@name", name);

				conn.Open();
				UserDTO? user = null;
				SqlDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					user = new UserDTO();
					user.Name = dr.GetString("name");
					user.Id = dr.GetInt32("id");
					user.Role = dr.GetString("role");
				}
				conn.Close();
				return user;
			}
		}

        public UserDTO? GetUserByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM SynUsers WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", id);

                UserDTO? user = null;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    user = new UserDTO();
                    user.Name = dr.GetString("name");
                    user.Id = id;
                }
                conn.Close();
                return user;
            }
        }

        public UserDTO? GetUserByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM SynUsers WHERE name = @name";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("name", name);

                UserDTO? user = null;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    user = new UserDTO();
                    user.Id = dr.GetInt32("id");
                    user.Name = dr.GetString("name");
                    user.Role = dr.GetString("role");
                }
                conn.Close();
                return user;
            }
        }

        public void CreateUser(string name, string password, string role)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"DECLARE @salt varchar(max) = crypt_gen_random(16);
                                INSERT INTO SynUsers(name,
                                                    password,
                                                    role,
                                                    salt)
                                            VALUES(@name,
                                                    hashbytes('SHA2_256', convert(varchar(max), concat(convert(varchar(max), @password), @salt))),
                                                    @role,
                                                    @salt);";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("password", password);
                cmd.Parameters.AddWithValue("role", role);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}