using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpankBank1.Interface;
using SpankBank1.Models;
using Microsoft.AspNetCore.Authorization;

namespace SpankBank1.Pages
{
    [Authorize(Roles = "Customer, Admin")]
    public class AdminPageModel : PageModel
    {
        private readonly IAccountService _bankService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminPageModel(IAccountService bankService, IHttpContextAccessor httpContextAccessor)
        {
            _bankService = bankService;
            _httpContextAccessor = httpContextAccessor;
        }

        public Account Account { get; set; }
        public IEnumerable<Account> Accounts { get; set; }

        public IActionResult OnGet()
        {
            var userEmail = _httpContextAccessor.HttpContext.User.Identity.Name; // Get the logged-in user's email
            Account = _bankService.GetAllAccounts().FirstOrDefault(a => a.Email == userEmail);
            if (Account == null)
            {
                return RedirectToPage("./Error"); // Or some other error page
            }

            return Page();
            //Accounts = _bankService.GetAllAccounts(); (OLD)
        }
    }
}
