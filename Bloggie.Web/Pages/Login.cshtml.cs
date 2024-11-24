using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace Bloggie.Web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login LoginViewMovel { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string ReturnUrl)
        {
            var signInResult = await signInManager.PasswordSignInAsync(LoginViewMovel.Username, LoginViewMovel.Password, false, false);

            if (signInResult.Succeeded)
            {
                if(!ReturnUrl.IsNullOrEmpty())
                {
                    return RedirectToPage(ReturnUrl);
                }

                return RedirectToPage("Index");
            }
            else
            {
                ViewData["Notificaiton"] = new Notification
                {
                    Type = Enums.NotificationType.Error,
                    Message = "Your credentials did not match our records"
                };

                return Page();
            }
        }
    }
}
