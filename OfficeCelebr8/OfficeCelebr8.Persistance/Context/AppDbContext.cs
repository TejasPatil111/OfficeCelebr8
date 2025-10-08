using Microsoft.EntityFrameworkCore;
using OfficeCelebr8.Domain.Models;

namespace OfficeCelebr8.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
