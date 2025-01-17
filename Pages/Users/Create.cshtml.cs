using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementApp.Models;
using UserManagementApp.Services;

namespace UserManagementApp.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly UserService _userService;

        public CreateModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; } = new();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _userService.AddUser(User);
            return RedirectToPage("./Index");
        }

      
    }

}
