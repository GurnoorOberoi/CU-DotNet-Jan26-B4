using MicroserviceAuthJWT.DTOs;
//using MicroserviceAuthJWT.Models;
//using MicroserviceAuthJWT.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAuthJWT.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TokenService _tokenService;

        public AuthController(UserManager<IdentityUser> userManager,
                              TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                //Role = dto.Role
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Assign role
            await _userManager.AddToRoleAsync(user, dto.Role);

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return Unauthorized("Invalid credentials");

            var roles = await _userManager.GetRolesAsync(user);

            var token = _tokenService.CreateToken(user, roles);

            return Ok(new { token });
        }
    }
}
