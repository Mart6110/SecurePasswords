using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecurePasswords.Interfaces;

namespace SecurePasswords.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(string username, string password)
        {
            if (_authenticationService.AuthenticateUser(username, password))
            {
                return RedirectToPage("/Index");
            }
            else
            {
                // Authentication failed
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return Page();
            }
        }
    }
}
