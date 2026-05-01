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

        // Register User

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var result = await _authService.RegisterAsync(dto);

            return Ok(new ApiResponse<AuthResponseDTO>
            {
                Success = true,
                Message = "User registered successfully",
                Data = result
            });
        }


        //Permit User Login 

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var result = await _authService.LoginAsync(dto);

            return Ok(new ApiResponse<AuthResponseDTO>
            {
                Success = true,
                Message = "Login successful",
                Data = result
            });
        }
    }
}