using Data;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Synthesis_assignment_web.Pages
{
    public class SubcategoryProductsModel : PageModel
    {
		DbProductHelper dbProductHelper;
		ProductManager productManager;
		public List<Product> Products { get; set; }
		public SubcategoryProductsModel()
		{
			dbProductHelper = new DbProductHelper();
			productManager = new ProductManager(dbProductHelper);
		}
		public void OnGet(string name)
		{
			Products = (List<Product>)productManager.GetProductsBySubCategory(name);
		}
	}
}
