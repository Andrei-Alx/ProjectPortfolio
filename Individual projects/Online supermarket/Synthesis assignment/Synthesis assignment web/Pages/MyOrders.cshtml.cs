using Data;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Synthesis_assignment_web.Pages
{
    [Authorize]
    public class MyOrdersModel : PageModel
    {
		IDbOrderHelper IdbOrderHelper;
		OrderManager orderManager;
		public List<Order> Orders { get; set; }
		public MyOrdersModel()
		{
			IdbOrderHelper = new DbOrderHelper();
			orderManager = new OrderManager(IdbOrderHelper);
			Orders = new List<Order>();
		}
		public void OnGet()
		{
			Orders = (List<Order>)orderManager.GetAllOrders();
		}
	}
}
