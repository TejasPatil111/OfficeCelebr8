using System.ComponentModel.DataAnnotations;

namespace OfficeCelebr8.Application.DTOs
{
    public class AddRoomDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; } = 2;

        [Required]
        public int CreatedBy { get; set; }

        [Required]
        public DateTime EventOn { get; set; }

        [Required]
        public int TotalCollection { get; set; }

        [Required]
        public List<int> MemberUserIds { get; set; } = new();
    }
}
