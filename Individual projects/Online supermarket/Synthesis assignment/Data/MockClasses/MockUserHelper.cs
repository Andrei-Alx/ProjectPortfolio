using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.MockClasses
{
	public class MockUserHelper : IDbUserHelper
	{
		public void CreateUser(string name, string password, string role)
		{
			
		}

		public UserDTO? FindUser(string name, string password)
		{
			UserDTO userDTO = new UserDTO();
			return userDTO;
		}

		public UserDTO? FindUser(string name)
		{
			UserDTO userDTO = new UserDTO();
			return userDTO;
		}

		public UserDTO? GetUserByID(int id)
		{
			UserDTO userDTO = new UserDTO();
			return userDTO;
		}

		public UserDTO? GetUserByName(string name)
		{
			return null;
		}

		public IEnumerable<UserDTO> GetUsers()
		{
			IEnumerable<UserDTO> userDTOs;
			userDTOs = new List<UserDTO>();
			return userDTOs;
		}
	}
}
