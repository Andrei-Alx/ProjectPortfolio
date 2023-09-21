using Data;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Synthesis_assignment_web.Pages
{
	[Authorize]
	public class CheckOutModel : PageModel
	{
		public int? UserId { get; set; }
		public User? User { get; set; }
		public UserManager UserManager { get; set; }
		public OrderManager OrderManager { get; set; }
		public IDbUserHelper IdbUserHelper { get; set; }
		public IDbOrderHelper IdbOrderHelper { get; set; }
		public List<OrderProduct>? Cart { get; set; }
		[BindProperty]
		public HomeDelivery HomeDelivery { get; set; }
		[BindProperty]
		public PickupDelivery PickupDelivery { get; set; }
		public string Time { get; set; }
		public decimal Total { get; set; }
		[BindProperty]
		public bool CBHomeDelivery { get; set; }
		[BindProperty]
		public bool CBPickupDelivery { get; set; }
		[BindProperty]
		public string DeliveryHour { get; set; }
		[BindProperty]
		public string DeliveryMinutes { get; set; }
		[BindProperty]
		public string PickUpHour { get; set; }
		[BindProperty]
		public string PickUpMinutes { get; set; }

		public CheckOutModel()
		{
			//ShippingInformation = new ShippingInformation();
			Cart = new List<OrderProduct>();
			IdbOrderHelper = new DbOrderHelper();
			OrderManager = new OrderManager(IdbOrderHelper);
			IdbUserHelper = new DbUserHelper();
			UserManager = new UserManager(IdbUserHelper);
		}
		public void OnGet()
		{
		}
		public void OnGetOrder(decimal total)
		{
			Cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
			Total = total;
		}

		public IActionResult OnPostChooseDelivery()
		{
			Cart = HttpContext.Session.GetObjectFromJson("cart");
			if (Cart == null)
			{
				Cart = new List<OrderProduct>();
			}
			else
			{
				foreach (OrderProduct product in Cart)
				{
					Total += product.Price;
				}
			}
			return Page();
		}


		public IActionResult OnPostCheckout()
		{
			Cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
			OrderManager = new OrderManager(IdbOrderHelper);
			List<Product> products = new List<Product>();
			string username = HttpContext.User.Identity.Name;
			User = UserManager.FindUser(username);

			foreach (OrderProduct orderProduct in Cart)
			{
				products.Add(orderProduct.Product);
			}

			if (CBHomeDelivery)
			{
				string time = DeliveryHour + ":" + DeliveryMinutes;
				if (OrderManager.IsAvailableTimeslot(time))
				{
					HomeDelivery = new HomeDelivery(HomeDelivery.Fullname, HomeDelivery.Email, HomeDelivery.Adress);
					OrderManager.AddOrder(User, products, 0, HomeDelivery, null, "Pending", time);
					return new RedirectToPageResult ("OrderConfirmation");
				}
				else
				{
					ViewData["Error"] = "That timeslot is full, please select a different one.";
				}
			}
			else if (CBPickupDelivery)
			{
				string time = PickUpHour + ":" + PickUpMinutes;
				if (OrderManager.IsAvailableTimeslot(time))
				{
					PickupDelivery = new PickupDelivery(PickupDelivery.Fullname, PickupDelivery.Email, PickupDelivery.Store);
					OrderManager.AddOrder(User, products, 0, null, PickupDelivery, "Pending", time);
					return new RedirectToPageResult("OrderConfirmation");
				}
				else
				{
					ViewData["Error"] = "That timeslot is full, please select a different one.";
				}
			}
			return Page();
		}

	}
}
