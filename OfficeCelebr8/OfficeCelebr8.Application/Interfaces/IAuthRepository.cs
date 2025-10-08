using OfficeCelebr8.Application.DTOs;

namespace OfficeCelebr8.Application.Interfaces
{
    public interface IAuthRepository
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<RegisterResponse> Register(RegisterRequest request);
    }
}
