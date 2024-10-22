using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpankBank1.Interface;
using SpankBank1.Services;

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

    public IActionResult OnPost(string pageType) {
        if (ModelState.IsValid)
        {
            _bankService.CreateAccount( Name, Email, Password);
            if (pageType == "Admin")
            {
                return RedirectToPage("/AdminPage");
            }
            else if (pageType == "Customer")
            {
                return RedirectToPage("/CustomerPage");
            }
        }

        return Page();
    }
}
