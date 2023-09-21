using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class User
    {
        public User()
        {
        }

        public User(UserDTO userDTO)
        {
            Id = userDTO.Id;
            Name = userDTO.Name;
            Password= userDTO.Password;
            Role = SetType(userDTO.Role);
        }

		public User(string username, string password, string role)
		{
			this.Name = username;
			this.Password = password;
			this.Role = SetType(role);
		}

		public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get; set; }

		public UserRoles SetType(string type)
		{
			UserRoles setType = UserRoles.Customer;

			switch (type)
			{
				case "Customer":
					setType = UserRoles.Customer;
					break;

				case "ShopWorker":
					setType = UserRoles.ShopWorker;
					break;
			}
			return setType;
		}

		public string GetType(UserRoles type)
		{
			string setType = "Customer";
			switch (type)
			{
				case UserRoles.ShopWorker:
					setType = "ShopWorker";
					break;

				case UserRoles.Customer:
					setType = "Customer";
					break;
			}
			return setType;
		}
	}
}
