using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
	public class HomeDelivery : DeliveryOption
	{
		private string adress;
		public HomeDelivery() : base() { }
		public HomeDelivery(HomeDeliveryDTO obj) : base(obj)
		{
			adress = obj.Adress;
		}
		public HomeDelivery(string fullname, string email, string adress)
		{
			this.Fullname = fullname;
			this.Email = email;
			this.Adress = adress;
		}
		public string Adress { get => adress; set => adress = value; }
	}
}
