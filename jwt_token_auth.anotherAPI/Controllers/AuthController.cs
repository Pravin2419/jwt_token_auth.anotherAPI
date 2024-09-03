using jwt_token_auth.anotherAPI.Models;
using jwt_token_auth.anotherAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwt_token_auth.anotherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [TypeFilter(typeof(CustomAuthorizationFilter))]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        

        public AuthController(IUserService userService)
        {
            this._userService = userService;
           
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User login)
        {
            var response = await _userService.AuthenticateAsync(login.Username, login.Password);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
        // Register Endpoint

        //PostApi
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
            {
                return BadRequest(new { message = "Username and password are required" });
            }

            var result = await _userService.RegisterAsync(user);

            if (result)
                return Ok(new { message = "User registered successfully" });
            else
                return BadRequest(new { message = "User registration failed" });
        }


    }
}

