using JwtAuthWebAPI.Models.DTO;
using JwtAuthWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthWebAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;

        public AuthController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            //Validate the incoming request by Fluent Validator

            // Check if user is authenticated
            // Check username and password
            var isAuthenticated = await userRepository.AuthenticateAsync(
                loginRequest.Username, loginRequest.Password);

            if (isAuthenticated)
            {
                //Generate a JWT

            }

            return BadRequest("Username or Password is incorrect.");
        }
    }
}
