using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpankBank1.Interface;
using SpankBank1.Services;
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
{
    private readonly IAccountService _bankService;

    public CreateModel(IAccountService bankService) {
        _bankService = bankService;
    }
  
    [BindProperty]
    public string Name { get; set; }

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Password { get; set; }

    [BindProperty]
    public string Role { get; set; } = "Customer"; // Default role
    
    public IActionResult OnPost() {
        if (ModelState.IsValid)
        {
            _bankService.CreateAccount( Name, Email, Password, Role);
            return RedirectToPage("./Index");
        }

        return Page();
    }
}
