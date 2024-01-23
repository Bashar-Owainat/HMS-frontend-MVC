using System.ComponentModel.DataAnnotations;

namespace mvc_app.Models.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public List<string> Roles { get; set; }
    }
}
