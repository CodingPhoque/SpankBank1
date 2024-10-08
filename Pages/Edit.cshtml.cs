using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpankBank1.Interface;
using SpankBank1.Models;
using SpankBank1.Services;
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin")]    
public class EditModel : PageModel
{
    private readonly IAccountService _bankService;

    public EditModel(IAccountService bankService) {
        _bankService = bankService;
    }
    [BindProperty]
    public Account Account { get; set; }
   
    public IActionResult OnGet(int id, string userEmail, string userRole) {
        Account = _bankService.GetAccountById(id, userEmail, userRole);
        if (Account == null)
        {
            return RedirectToPage("./Index");
        }
        return Page();
    }
   
    public IActionResult OnPost(string userEmail, string userRole) {
        if (ModelState.IsValid)
        {
            _bankService.UpdateAccount(Account, userEmail, userRole);
            return RedirectToPage("./Index");
        }
        return Page();
    }
}

