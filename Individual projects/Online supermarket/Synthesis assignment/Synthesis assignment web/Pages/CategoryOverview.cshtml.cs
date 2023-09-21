using Data;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Synthesis_assignment_web.Pages
{
    public class CategoryOverviewModel : PageModel
    {
		CategoryManager categoryManager;
		public List<Category> Categories { get; set; }
		public CategoryOverviewModel()
		{
			categoryManager = new CategoryManager();
			Categories= new List<Category>();
		}
		public void OnGet()
		{
			Categories = (List<Category>)categoryManager.GetAllCategories();
		}
	}
}
