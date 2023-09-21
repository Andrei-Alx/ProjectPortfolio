using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	public class HomeDeliveryDTO
	{
		private string fullname;
		private string email;
		private string adress;

		public HomeDeliveryDTO(string fullname, string email, string adress)
		{
			this.Fullname = fullname;
			this.Email = email;
			this.Adress = adress;
		}

		public string Fullname { get => fullname; set => fullname = value; }
		public string Email { get => email; set => email = value; }
		public string Adress { get => adress; set => adress = value; }
	}
}
