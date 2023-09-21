using Data;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Synthesis_assignment_web.Pages
{
    public class SubcategoryOverviewModel : PageModel
    {
        private int productId = 0;
        private readonly DbCategoryHelper dbCategoryHelper;
        private readonly CategoryManager categoryManager;


        public Category category { get; set; }

        public List<Category> SubCategories { get; set; }

        public SubcategoryOverviewModel()
        {
			dbCategoryHelper = new DbCategoryHelper();
            categoryManager = new CategoryManager();

			SubCategories = new List<Category>();
        }
        public void OnGet(int id)
        {
			SubCategories = categoryManager.GetSubCategories(id);
        }
    }
}
