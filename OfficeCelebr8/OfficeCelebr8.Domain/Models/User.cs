using System.ComponentModel.DataAnnotations;
using OfficeCelebr8.Domain.Constants;

namespace OfficeCelebr8.Domain.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
        public Role Role { get; set; } = Role.Employee;

    }
}
