using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecurePasswords.Interfaces;

namespace SecurePasswords.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(string username, string password)
        {
            _authenticationService.RegisterUser(username, password);
            return RedirectToPage("/Index");
        }
    }
}
