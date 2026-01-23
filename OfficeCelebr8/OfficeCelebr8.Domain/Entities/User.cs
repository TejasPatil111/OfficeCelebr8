using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeCelebr8.Domain.Entities
{
    public class User
    
        {
        public int Id { get; set; } 
        public string? UserName { get; set; } 
        public string? Email { get; set; } = string.Empty;
        public string? PasswordHash { get; set; } 
        public string Role { get; set; } = "User";
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public string createdBy { get; set; }
       
    }

}
