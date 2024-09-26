using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpankBank1.Interface;
using SpankBank1.Models;
using SpankBank1.Services;

namespace SpankBank1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _bankService;

        public IndexModel(IAccountService bankService) {
            _bankService = bankService;
        }

        public IEnumerable<Account> Accounts { get; set; }

        public void OnGet() {
            Accounts = _bankService.GetAllAccounts();
        }
    }
}
