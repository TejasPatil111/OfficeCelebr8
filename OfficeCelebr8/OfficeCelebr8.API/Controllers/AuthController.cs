using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeCelebr8.Application.DTOs;
using OfficeCelebr8.Application.Interfaces;

namespace OfficeCelebr8.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            return Ok(await _authRepository.Login(request));
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            return Ok(await _authRepository.Register(request));
        }
    }
}
