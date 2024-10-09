using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpankBank1.Interface;
using SpankBank1.Models;

namespace SpankBank1.Pages
{
    public class DepositModel : PageModel
    {
        private readonly IAccountService _bankService;

        public DepositModel(IAccountService bankService) {
            _bankService = bankService;
        }

        [BindProperty]
        public decimal Balance { get; set; }

        [BindProperty]
        public int AccountId { get; set; } // Store the account ID

        public void OnGet(int id) {
            // Retrieve the account using the account ID
            var account = _bankService.GetAccountById(id);

            // If the account is found, set the Balance and AccountId properties
            if (account != null)
            {
                Balance = account.Balance;
                AccountId = account.Id;
            }
        }

        public IActionResult OnPost(int id, decimal amount) {
            if (ModelState.IsValid)
            {
                // Deposit the specified amount to the account
                _bankService.DepositAccount(id, amount);

                // Reload the page with the updated balance
                return RedirectToPage(new { id = id });
            }

            return Page();
        }
    }
}

