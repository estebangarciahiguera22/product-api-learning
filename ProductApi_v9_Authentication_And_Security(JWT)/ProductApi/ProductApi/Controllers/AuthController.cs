using Microsoft.AspNetCore.Mvc;
using ProductApi.DTOs;
using ProductApi.Services;
using ProductApi.Responses;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var result = _authService.Login(dto);

            return Ok(new ApiResponse<AuthResponseDTO>
            {
                Success = true,
                Message = "Login successful",
                Data = result
            });
        }
    }
}