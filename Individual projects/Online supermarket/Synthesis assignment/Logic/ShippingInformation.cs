using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
	public class ShippingInformation
	{
		public ShippingInformation()
		{

		}

		public ShippingInformation(string? adress, string? city, string? region, string? postalCode, string? store)
		{
			Adress = adress;
			City = city;
			Region = region;
			PostalCode = postalCode;
			Store = store;
		}
		public string? Adress { get; set; }

		public string? City { get; set; }

		public string? Region { get; set; }

		[RegularExpression("/^[1-9][0-9]{3} ?(?!sa|sd|ss)[A-Z]{2}$/i", ErrorMessage ="Incorrect postcode format!")]
		public string? PostalCode { get; set; }

		public string? Store { get; set; }
	}
}
