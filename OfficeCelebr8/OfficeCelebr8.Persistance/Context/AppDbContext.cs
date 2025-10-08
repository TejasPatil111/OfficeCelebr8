using Microsoft.EntityFrameworkCore;
using OfficeCelebr8.Domain.Models;

namespace OfficeCelebr8.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomMember> RoomMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomMember>().HasKey(rm => new { rm.RoomId, rm.EmployeeId });
        }
    }
}
