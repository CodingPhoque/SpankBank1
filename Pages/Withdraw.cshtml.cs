using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpankBank1.Interface;

namespace SpankBank1.Pages
{
    public class WithdrawModel : PageModel {
        private readonly IAccountService _bankService;

        public WithdrawModel(IAccountService bankService) {
            _bankService = bankService;
        }

        [BindProperty]
        public decimal Balance { get; set; }
        [BindProperty]
        public int AccountId { get; set; } // Store the account ID

        public void OnGet(int id) {
            var account = _bankService.GetAccountById(id);

            if (account != null)
            {
                Balance = account.Balance;
                AccountId = account.Id;
                //Balance = 0; // initial balance

            }
        }
            public IActionResult OnPost(int id, decimal amount) {
                if (ModelState.IsValid)
                {
                    _bankService.WithdrawAccount(id, amount);
                }
                // Reload the page with the updated balance
                return RedirectToPage(new { id = id });
            }

        
    }
}
