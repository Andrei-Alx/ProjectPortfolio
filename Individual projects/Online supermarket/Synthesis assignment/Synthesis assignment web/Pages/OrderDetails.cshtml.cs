using Data;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Synthesis_assignment_web.Pages
{
    public class OrderDetailsModel : PageModel
    {
		private IDbOrderHelper IdbOrderHelper;
		private OrderManager orderManager;
		public Order Order { get; set; }

		public OrderDetailsModel()
		{
			IdbOrderHelper = new DbOrderHelper();
			orderManager = new OrderManager(IdbOrderHelper);
			Order order = new Order();
		}
		public void OnGetDetails(int id)
		{
			Order = orderManager.GetOrder(id);
		}
	}
}
