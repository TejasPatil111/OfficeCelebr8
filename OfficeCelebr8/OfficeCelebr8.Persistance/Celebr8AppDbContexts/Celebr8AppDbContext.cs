using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeCelebr8.Domain.Entities;

namespace OfficeCelebr8.Persistance.Celebr8AppDbContexts
{
    public class Celebr8AppDbContext : DbContext
    {
        public Celebr8AppDbContext(DbContextOptions<Celebr8AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
