using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpankBank1.DAL; // Make sure to include the namespace for your BankContext
using System.Security.Claims;

namespace SpankBank1.Pages
{
    public class LoginModel : PageModel
    {
        private readonly BankContext _context; // Declare the context

        // Constructor to inject the context
        public LoginModel(BankContext context) {
            _context = context; // Assign the injected context to the private field
        }

        public async Task<IActionResult> OnPostLoginAsync(string email, string password) {
            // Use the injected _context to query the database
            var account = await _context.BankAccounts.SingleOrDefaultAsync(a => a.Email == email && a.Password == password);

            if (account != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.Email),
                    new Claim(ClaimTypes.Role, account.Role)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                if (account.Role == "Admin")
                {
                    return RedirectToPage("/Admin/Dashboard");
                }
                else
                {
                    return RedirectToPage("/Customer/Dashboard");
                }
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return Page();
        }
    }
}
