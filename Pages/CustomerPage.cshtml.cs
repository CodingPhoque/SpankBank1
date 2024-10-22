using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpankBank1.Interface;
using SpankBank1.Models;

namespace SpankBank1.Pages
{
    public class CustomerPage : PageModel
    {
        private readonly IAccountService _bankService;

        public CustomerPage(IAccountService bankService)
        {
            _bankService = bankService;
        }

        public IEnumerable<Account> Accounts { get; set; }

        public void OnGet()
        {
            Accounts = _bankService.GetAllAccounts();
        }
    }
}
