using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpankBank1.Pages
{
    public class DepositModel : PageModel
    {
        public decimal Balance { get; set; }

        public void OnGet()
        {
            
                Balance = 0; // initial balance
            
        }

        public IActionResult OnPost(decimal amount)
        {
            Balance += amount;
            return Page();
        }

    }
}
