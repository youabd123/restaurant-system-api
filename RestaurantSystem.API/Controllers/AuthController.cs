using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Infrastructure.Repositories;

namespace RestaurantSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            var ok = await _auth.Register(username, password);
            return ok ? Ok("User created") : BadRequest("User already exists");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var ok = await _auth.Login(username, password);
            return ok ? Ok("Login successful") : BadRequest("Invalid credentials");
        }
    }
}
