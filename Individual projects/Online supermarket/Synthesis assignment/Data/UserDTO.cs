using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Data
{
    public class UserDTO
    {
        public UserDTO()
        {
        }

		public UserDTO(string username, string password, string role)
		{
			this.Name = username;
			this.Password = password;
			this.Role = role;
		}
		public UserDTO(string username, string role)
		{
			this.Name = username;
			this.Role = role;
		}
		public UserDTO(UserDTO u)
		{
			Id = u.Id;
			Name = u.Name;
			Role = u.Role;
		}

		public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
