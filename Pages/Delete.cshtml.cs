using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpankBank1.Interface;
using SpankBank1.Models;
using SpankBank1.Services;
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin")]
public class DeleteModel : PageModel
{
    private readonly IAccountService _bankService;

    public DeleteModel(IAccountService bankService) {
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

    public IActionResult OnPost(int id) {
        var userEmail = User.Identity.Name; // Get the logged-in user's email
        var userRole = User.IsInRole("Admin") ? "Admin" : "Customer"; // Determine the user's role

        _bankService.DeleteAccount(id, userEmail, userRole); // Pass email and role to the service

        return Page();
        /*_bankService.DeleteAccount(id);
        return RedirectToPage("./Index");*/
    }
}
