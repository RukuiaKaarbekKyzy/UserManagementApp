using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementApp.Models;
using UserManagementApp.Services;

namespace UserManagementApp.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly UserService _userService;

        public DeleteModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; } = new();
        public IActionResult OnGet(int id)
        {
            var User = _userService.GetById(id);
            if (User == null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            _userService.Delete(User.Id);
            return RedirectToPage("./Index");
        }
    }
}
