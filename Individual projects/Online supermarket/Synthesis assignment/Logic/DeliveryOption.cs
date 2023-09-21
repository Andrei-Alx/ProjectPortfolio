using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
	public class DeliveryOption
	{
		private string fullname;
		private string email;
		public DeliveryOption() 
		{
			
		}
		protected DeliveryOption(PickupDeliveryDTO pickupDeliveryDTO)
		{
			fullname = pickupDeliveryDTO.Fullname;
			email = pickupDeliveryDTO.Email;
		}
		protected DeliveryOption(HomeDeliveryDTO obj)
		{
			fullname = obj.Fullname;
			email = obj.Email;
		}
		protected DeliveryOption(string fullname, string email)
		{
			this.fullname = fullname;
			this.email = email;
		}
		public string Fullname { get => fullname; set => fullname = value; }
		public string Email { get => email; set => email = value; }
	}
}
