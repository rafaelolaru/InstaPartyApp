using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InstaPartyApp.Services;
using Microsoft.Win32;

namespace InstaPartyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthController(IConfiguration configuration, IAuthService authService, IPasswordHasher passwordHasher)
        {
            _configuration = configuration;
            _authService = authService;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var user = _authService.ValidateUser(login.Username, login.Password);
            if (user != null)
            {
                var token = GenerateJwtToken(user.Username, user.UserId);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }


        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel register)
        {
            var existingUser = _authService.GetUserByUsername(register.Username);
            if (existingUser != null)
            {
                return BadRequest("User already exists.");
            }

            var newUser = _authService.CreateUser(register);

            var token = GenerateJwtToken(newUser.Username, newUser.UserId);
            return Ok(new { Token = token });
        }

    private string GenerateJwtToken(string username, int userId)
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var claims = new[]
      {
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim("userid", userId.ToString()) // Using "userid" as a custom claim type
    };

      var token = new JwtSecurityToken(
          issuer: _configuration["Jwt:Issuer"],
          audience: _configuration["Jwt:Audience"],
          claims: claims,
          expires: DateTime.Now.AddMinutes(30),
          signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
