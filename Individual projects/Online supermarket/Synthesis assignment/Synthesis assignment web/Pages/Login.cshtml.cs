using Logic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Text.Json;
using Data;

namespace Synthesis_assignment_web.Pages
{
    public class LoginModel : PageModel
    {
		public const string RememberMeCookiename = "RememberMe";

		[BindProperty]
		public Credentials Credentials { get; set; }
		private LoginManager LoginManager { get; set; }

		private readonly IDbUserHelper IDbUserHelper;
		private User? CurrentUser { get; set; }
		private UserManager UserManager { get; set; }

		public LoginModel()
		{
			Credentials = new Credentials();
			IDbUserHelper = new DbUserHelper();
			LoginManager = new LoginManager();
			CurrentUser = new User();
			UserManager = new UserManager(IDbUserHelper);
		}

		public async Task<IActionResult> OnGet()
		{
			if (Request.Cookies.ContainsKey("Credentials"))
			{
				string? test = Request.Cookies["Credentials"];
				if (test == string.Empty || test == null)
				{
					return Page();
				}
				else
				{
					Credentials? c = JsonSerializer.Deserialize<Credentials>(Request.Cookies["Credentials"]);
					if(ModelState.IsValid && EmailValidation.IsValidUsername(Credentials.Email))
					{
						List<Claim> claims = new List<Claim>();
						claims.Add(new Claim(ClaimTypes.Name, c.Email));

						ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
						await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
						return RedirectToPage("Profile");
					}
				}
			}
			return Page();
		}

		public async Task<IActionResult> OnPostLogIn()
		{
			if (ModelState.IsValid)
			{
				if ((bool)this.Credentials.RememberMe)
				{
					CookieOptions cookieOptions = new CookieOptions();
					cookieOptions.Expires = DateTime.Now.AddDays(5);
					Response.Cookies.Append("Credentials", JsonSerializer.Serialize(Credentials), cookieOptions);
				}
				CurrentUser = LoginManager.Login(Credentials.Email, Credentials.Password);
				if (CurrentUser != null)
				{
					List<Claim> claims = new List<Claim>();
					claims.Add(new Claim(ClaimTypes.Name, this.Credentials.Email));

					ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
					return RedirectToPage("Profile");
				}
				else
				{
					return RedirectToPage("AccessDenied");
				}
			}
			return Page();
		}

		public void OnPostSignUp()
		{
			try
			{
				UserManager.CreateUser(Credentials.Email, Credentials.Password, UserRoles.Customer);
			}
			catch (Exception ex)
			{
				ViewData["SignUp"] = ex.Message;
			}
		}
	}
}
