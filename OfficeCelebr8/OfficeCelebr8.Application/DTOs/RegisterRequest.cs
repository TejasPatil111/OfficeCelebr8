namespace OfficeCelebr8.Application.DTOs
{
    public class RegisterRequest
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
    }
}
