using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using W18.Application.IServices;
using W18_Domain.Models;

namespace W18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthService _authService;

        public AuthController(UserManager<User> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return Unauthorized("Invalid Email or Password.");
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!result)
            {
                return Unauthorized("Invalid Email or Password.");
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var token = _authService.GenerateToken(user, userRoles);

            return Ok(new
            {
                token = token,
                expiration = DateTime.UtcNow.AddHours(2),
                userEmail = user.Email
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return BadRequest("User already exists!");

            User user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest("User creation failed! Check password requirements.");

            return Ok("User created successfully!");
        }

        public class RegisterRequest
        {
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}