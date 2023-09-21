using Data;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Synthesis_assignment_web.Pages
{
    public class Product_overviewModel : PageModel
    {
        IDbProductHelper dbProductHelper;
        ProductManager productManager;
        public List<Product> Products { get; set; }
        public Product_overviewModel()
        {
            dbProductHelper = new DbProductHelper();
            productManager = new ProductManager(dbProductHelper);
            Products= new List<Product>();
        }
        public void OnGet()
        {
            Products = (List<Product>)productManager.GetAllAvailable();
        }
		public void OnGetFilter(string subCategory)
		{
			Products = (List<Product>)productManager.GetProductsBySubCategory(subCategory);
		}
	}
}
