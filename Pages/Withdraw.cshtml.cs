using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpankBank1.Interface;

namespace SpankBank1.Pages
{
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
            if (ModelState.IsValid)
            {
                _bankService.WithdrawAccount(id, amount);
            }
            return Page();
        }

    }
}
