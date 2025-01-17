using System.ComponentModel.DataAnnotations;

namespace UserManagementApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "name cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "email cannot be empty and wrong")]
        [EmailAddress(ErrorMessage ="Wrong email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Role cannot be empty")]
        public string Role{ get; set; }
    }
}
