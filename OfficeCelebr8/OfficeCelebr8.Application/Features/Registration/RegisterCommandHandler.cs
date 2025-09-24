using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OfficeCelebr8.Domain.Interfaces;
using OfficeCelebr8.Domain.Entities;
using Microsoft.AspNetCore.Identity;


namespace OfficeCelebr8.Application.Features.Registration
{
    public class RegisterCommandHandler : IRequestHandler<RegistrationCommand, int>
    {
        private readonly IUserRepository _repo;
        private readonly IPasswordHasher<User> _passwordHasher;

        public RegisterCommandHandler( IUserRepository repo , IPasswordHasher<User> passwordHasher )
        {
           _repo = repo;
            _passwordHasher = passwordHasher;
        }
        public async Task<int> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var existing = await _repo.GetByEmailAsync(dto.Email);
            if (existing != null)
            {
                throw new InvalidOperationException("Email Already Exist");
            }
            var User = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Role = "User",
                CreatedAtUtc = DateTime.UtcNow
            };
            var UserPasswordHasher = _passwordHasher.HashPassword(User, dto.Password);
            return await _repo.AddAsync(User);
        }
    }
}
