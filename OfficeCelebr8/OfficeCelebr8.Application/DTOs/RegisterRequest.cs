using System.ComponentModel.DataAnnotations;

namespace OfficeCelebr8.Application.DTOs
{
    public class RegisterRequest
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(8), MaxLength(15)]
        public string Password { get; set; }

        [Required]
        public string Designation { get; set; }
    }
}
