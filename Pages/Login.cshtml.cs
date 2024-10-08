using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpankBank1.Models;
using System.Security.Authentication;
using System.Text.Json;

namespace SpankBank1.Pages
{
    public class LoginModel : PageModel
    {
        public Admin Admin {  get; set; }

        private List<Admin> LoadUsers()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "Admin.json");
            var jsonData = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Admin>>(jsonData);
        }

            public void OnGet()
        {
        }
        public IActionResult OnPost()
            {
                var users = LoadUsers();
                var user = users.Find(u => u.AdminName == Admin.AdminName && u.Password == Admin.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString("AdminName", user.AdminName);
                    return RedirectToPage("AdminPage");
                }
                else
                {
                throw new AuthenticationException("Invalid username or password");
                }
            }


        }
}
