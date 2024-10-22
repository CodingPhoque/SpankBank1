using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpankBank1.Interface;
using SpankBank1.Models;
using SpankBank1.Services;

public class DeleteModel : PageModel
{
    private readonly IAccountService _bankService;

    public DeleteModel(IAccountService bankService) {
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

    public IActionResult OnPost(int id) {
        _bankService.DeleteAccount(id);
        return RedirectToPage("./AdminPage");
    }
}
