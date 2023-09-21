using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
	public class Credentials
	{
		public Credentials()
		{
		}

		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}
