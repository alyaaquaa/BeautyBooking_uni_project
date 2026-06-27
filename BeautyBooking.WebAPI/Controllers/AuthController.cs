using BeautyBooking.Application.Services;
using BeautyBooking.SharedKernel.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BeautyBooking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = await _authService.RegisterAsync(dto);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _authService.LoginAsync(dto);

            if (user == null)
                return Unauthorized("Nieprawidłowy email lub hasło.");

            return Ok(user);
        }
    }
}