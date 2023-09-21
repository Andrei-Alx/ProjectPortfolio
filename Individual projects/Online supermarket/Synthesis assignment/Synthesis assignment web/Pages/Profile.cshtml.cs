using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Synthesis_assignment_web.Pages
{
	[Authorize]
	public class ProfileModel : PageModel
    {
		public void OnGet()
		{
		}
		public async Task<IActionResult> OnPostLogout()
		{
			await HttpContext.SignOutAsync();
			Response.Cookies.Append("Credentials", string.Empty);
			return RedirectToPage("/Index");
		}
	}
}
