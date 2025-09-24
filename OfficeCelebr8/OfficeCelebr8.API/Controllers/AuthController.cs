using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeCelebr8.Application.Features.Login;
using OfficeCelebr8.Application.Features.Registration;

namespace OfficeCelebr8.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator) => mediator = _mediator;

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _mediator.Send(new LoginQuery(dto));
            return Ok(new { token });
        }

        [HttpPost]
        public async Task<IActionResult> register([FromBody] RegistrationDto dto)
        {
            var id = await _mediator.Send(new RegistrationCommand(dto));
            return CreatedAtAction(nameof(register), new { id });
        }

    }
}