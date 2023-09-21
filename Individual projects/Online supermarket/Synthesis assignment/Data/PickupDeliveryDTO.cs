using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	public class PickupDeliveryDTO
	{
		private string fullname;
		private string email;
		private string store;
		public PickupDeliveryDTO(string fullname, string email, string store)
		{
			this.fullname = fullname;
			this.email = email;
			this.store = store;
		}
		public string Fullname { get => fullname; set => fullname = value; }
		public string Email { get => email; set => email = value; }
		public string Store { get => store; set => store = value; }
	}
}
