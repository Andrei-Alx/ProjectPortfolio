using Data;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Synthesis_assignment_web.Pages
{
    public class CartModel : PageModel
    {
		public List<OrderProduct>? cart { get; set; }
		public decimal Total { get; set; }
		[BindProperty]
		public OrderProduct OrderProduct { get; set; }
		public void OnGet()
		{
			cart = HttpContext.Session.GetObjectFromJson("cart");
			if (cart is null)
			{
				cart = new List<OrderProduct>();
				OrderProduct = new OrderProduct();
			}
			else
			{
				foreach (OrderProduct product in cart)
				{
					Total += product.Price;
				}
			}
		}

		public IActionResult OnGetBuyNow(string id)
		{
			IDbProductHelper IDbProductHelper = new DbProductHelper();
			ProductManager productManager = new ProductManager(IDbProductHelper);
			cart = HttpContext.Session.GetObjectFromJson("cart");
			if (cart == null)
			{
				cart = new List<OrderProduct>();
				OrderProduct orderProduct = new OrderProduct(productManager.Finder(Convert.ToInt32(id)), 1);
				cart.Add(orderProduct);
				SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
			}
			else
			{
				int index = Exists(id);
				if (index == -1)
				{
					OrderProduct orderProduct = new OrderProduct(productManager.Finder(Convert.ToInt32(id)), quantity: 1);
					cart.Add(orderProduct);
				}
				else
				{
					cart.ElementAt(index).Quantity++;
					cart.ElementAt(index).Price = cart.ElementAt(index).Quantity * cart.ElementAt(index).Product.Price;
				}
				SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
			}
			return RedirectToPage("Cart");
		}

		public IActionResult OnGetDelete(string id)
		{
			cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
			int index = Exists(id);
			cart.RemoveAt(index);
			SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
			return RedirectToPage("Cart");
		}

		private int Exists(string id)
		{
			List<OrderProduct>? cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
			for (int i = 0; i < cart.Count; i++)
			{
				if (cart.ElementAt(i).Product.Id == Convert.ToInt32(id))
				{
					return i;
				}
			}
			return -1;
		}
	}
}
