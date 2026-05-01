using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProductApi.DTOs;
using ProductApi.Exceptions;
using ProductApi.Models;

namespace ProductApi.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;

        // Temporary in-memory user list for learning purposes.
        // In a real project, users should be stored in the database with hashed passwords.
        private readonly List<User> _users = new()
        {
            new User
            {
                Id = 1,
                Username = "admin",
                Password = "1234",
                Role = "Admin"
            }
        };

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Validates user credentials and returns a JWT token.
        public AuthResponseDTO Login(LoginDTO loginDto)
        {
            var user = _users.FirstOrDefault(u =>
                u.Username == loginDto.Username &&
                u.Password == loginDto.Password);

            if (user == null)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var token = GenerateJwtToken(user);

            return new AuthResponseDTO
            {
                Token = token
            };
        }

        // Generates a JWT token with basic user claims.
        private string GenerateJwtToken(User user)
        {
            var jwtKey = _configuration["Jwt:Key"];

            if (string.IsNullOrWhiteSpace(jwtKey))
            {
                throw new Exception("JWT key is not configured");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}