using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpankBank1.Interface;
using Microsoft.AspNetCore.Authorization;

namespace SpankBank1.Pages
{
    [Authorize(Roles = "Admin")]
    public class WithdrawModel : PageModel
    {
        private readonly IAccountService _bankService;

        public WithdrawModel(IAccountService bankService)
        {
            _bankService = bankService;
        }

        [BindProperty]
        public decimal Balance { get; set; }

        public void OnGet()
        {

            Balance = 0; // initial balance

        }

        public IActionResult OnPost(int id, decimal amount)
        {
            var userEmail = User.Identity.Name; // Get the logged-in user's email
            var userRole = User.IsInRole("Admin") ? "Admin" : "Customer"; // Determine the user's role

            _bankService.WithdrawAccount(id, amount, userEmail, userRole); // Pass email and role to the service

            return Page();
            /*if (ModelState.IsValid)
            {
                _bankService.WithdrawAccount(id, amount);
            }
            return Page();*/
        }

    }
}
