using System.ComponentModel.DataAnnotations;

namespace OfficeCelebr8.Domain.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; } = 2;

        [Required]
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public DateTime EventOn { get; set; }

        [Required]
        public int TotalCollection { get; set; }
        public int CollectedTillNow { get; set; } = 0;

        // Navigation property - One Room has many RoomMembers
        public ICollection<RoomMember> Members { get; set; } = new List<RoomMember>();
    }
}
