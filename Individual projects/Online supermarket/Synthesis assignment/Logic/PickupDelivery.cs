using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
	public class PickupDelivery : DeliveryOption
	{
		private string store;
		public PickupDelivery() : base() { }
		public PickupDelivery(PickupDeliveryDTO pickUpDTO) : base(pickUpDTO)
		{
			store = pickUpDTO.Store;
		}
		public PickupDelivery(string fullname, string email, string store) : base(fullname, email)
		{
			this.store = store;
		}
		public string Store { get => store; set => store = value; }
	}
}
