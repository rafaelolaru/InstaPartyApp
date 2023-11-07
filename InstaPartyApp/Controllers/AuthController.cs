using InstaPartyApp.BusinessLogic.Services;
using InstaPartyApp.Models;
using Microsoft.AspNetCore.Mvc;
// Include any other namespaces required by LoginModel or AuthenticationService

namespace YourProjectName.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService _authService;

        public AuthController(AuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Validate the user credentials here (not shown)
            // ...

            // If credentials are valid, generate JWT token
            var token = _authService.GenerateJwtToken(login.Username);

            return Ok(new { Token = token });
        }
    }
}
