using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeCelebr8.Domain.Interfaces;
using OfficeCelebr8.Domain.Entities;
using OfficeCelebr8.Persistance.Celebr8AppDbContexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace OfficeCelebr8.Persistance.Repsitories
{
    public class UserRepository : IUserRepository
    {
        private readonly Celebr8AppDbContext _context;

        public UserRepository(Celebr8AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<User?> GetByEmailAsync(string email)
        =>await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User?> GetByIdAsync(int id)
        =>await  _context.Users.FindAsync(id);

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            
        }
    }
}
