using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpankBank1.Pages
{
    public class WithdrawModel : PageModel
    {
        public decimal Balance { get; set; }

        public void OnGet()
        {
            Balance = 0; // initial balance
        }

        public IActionResult OnPost(decimal amount)
        {
            if (amount > Balance)
            {
                ModelState.AddModelError("amount", "Insufficient funds");
                return Page();
            }
            Balance -= amount;
            return Page();
        }
    }
}
