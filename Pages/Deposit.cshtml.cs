using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpankBank1.Interface;
using SpankBank1.Models;

namespace SpankBank1.Pages
{
    public class DepositModel : PageModel
    {
        public Account Account { get; set; }
        public decimal DepositAmount { get; set; }

        private readonly IAccountService _bankService;

        public DepositModel(IAccountService bankService)
        {
            _bankService = bankService;
        }

        [BindProperty]
        public decimal Balance { get; set; }

        //public void OnGet()
        //{

        //        //Balance = 0; // initial balance


        //}

        public IActionResult OnGet(int id)
        {
            Account = _bankService.GetAccountById(id);
            return Page();
        }

        //public IActionResult OnPost(int id, decimal amount)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _bankService.DepositAccount(id, amount);

        //    }
        //    return Page();
        //}

        public IActionResult OnPost(int id, decimal amount)
        {
            if (ModelState.IsValid)
            {
                _bankService.DepositAccount(id, amount);
                Account = _bankService.GetAccountById(id);
            }
            return Page();
        }


    }
}
