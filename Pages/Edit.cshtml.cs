using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpankBank1.Interface;
using SpankBank1.Models;
using SpankBank1.Services;

public class EditModel : PageModel
{
    private readonly IAccountService _bankService;

    public EditModel(IAccountService bankService) {
        _bankService = bankService;
    }

    [BindProperty]
    public Account Account { get; set; }

    public IActionResult OnGet(int id) {
        Account = _bankService.GetAccountById(id);
        if (Account == null)
        {
            return RedirectToPage("./Index");
        }
        return Page();
    }

    public IActionResult OnPost() {
        if (ModelState.IsValid)
        {
            _bankService.UpdateAccount(Account);
            return RedirectToPage("./Index");
        }
        return Page();
    }
}

