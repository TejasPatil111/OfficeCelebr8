using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OfficeCelebr8.Domain.Entities;
using OfficeCelebr8.Domain.Interfaces;

namespace OfficeCelebr8.Application.Features.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery , string>
    {
        private readonly IUserRepository _repo;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtTokenGenrator _jwtTokenGenrater;

        public LoginQueryHandler(IUserRepository repo, IPasswordHasher<User> PasswordHasher, IJwtTokenGenrator jwtTokenGenrater)
        {
            _repo = repo;
            _passwordHasher = PasswordHasher;
            _jwtTokenGenrater = jwtTokenGenrater;
        }

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var dto = request.dto;
            var user =await _repo.GetByEmailAsync(dto.Email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid Email/ doesnt exist ");
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new UnauthorizedAccessException("Invalid Password");
            }
            return _jwtTokenGenrater.GenrateToken(user);

        }
    }
}
