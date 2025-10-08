using Microsoft.EntityFrameworkCore;
using OfficeCelebr8.Application.DTOs;
using OfficeCelebr8.Application.Interfaces;
using OfficeCelebr8.Domain.Models;
using OfficeCelebr8.Persistance.Context;

namespace OfficeCelebr8.Persistance.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;
        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var findUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (findUser == null)
            {
                throw new Exception("User/Employee does not exist on OfficeCelebr8 :(");
            }
            var checkPswd = findUser.Password.Equals(request.Password);
            if (checkPswd == false)
            {
                throw new Exception("Incorrect Password or Email :(");
            }
            return new LoginResponse
            {
                IsLoggedIn = true
            };
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            var checkUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (checkUser != null)
            {
                throw new Exception("User/Employee already exists! Please log in.");
            }
            var registerUser = new User
            {
                EmployeeId = request.EmployeeId,
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Designation = request.Designation
            };
            await _context.Users.AddAsync(registerUser);
            if (await _context.SaveChangesAsync() <= 0)
            {
                throw new Exception("For some reasons, user has not been registered. :(");
            }
            return new RegisterResponse
            {
                Id = _context.Users.FirstOrDefault(u => u.Email == request.Email)!.Id,
                IsRegistered = true
            };
        }
    }
}
