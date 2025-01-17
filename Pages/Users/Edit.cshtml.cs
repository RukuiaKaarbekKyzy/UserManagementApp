using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementApp.Models;
using UserManagementApp.Services;

namespace UserManagementApp.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly UserService _userService;

        public EditModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var userFromDb = _userService.GetById(id);
            if (userFromDb == null)
            {
                return RedirectToPage("./Index");
            }

            User = userFromDb; 
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _userService.Update(User); 
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }


}
