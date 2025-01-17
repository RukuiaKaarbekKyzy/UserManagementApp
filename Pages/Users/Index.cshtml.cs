using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementApp.Models;
using UserManagementApp.Services;

namespace UserManagementApp.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly UserService _userService;

        public IndexModel(UserService userService)
        {
            _userService = userService;
        }
        public List<User> Users { get; set; } = new();
        public void OnGet()
        {
            Users = _userService.GetUsers();
        }
    }
}
