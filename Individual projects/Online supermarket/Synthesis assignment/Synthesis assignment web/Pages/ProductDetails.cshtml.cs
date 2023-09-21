using Data;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Synthesis_assignment_web.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private int productId = 0;
        private readonly DbProductHelper dbProductHelper;
        private readonly ProductManager productManager;


        public Product Product { get; set; }

        public List<Product> Products { get; set; }

        public ProductDetailsModel()
        {
            dbProductHelper = new DbProductHelper();
            productManager = new ProductManager(dbProductHelper);

            Products = new List<Product>();
            Products = productManager.GetAll().ToList();

        }
        public void OnGet(int id)
        {
            foreach (Product product in Products)
            {
                if (product.Id == id)
                    Product = product;

            }
        }
    }
}
