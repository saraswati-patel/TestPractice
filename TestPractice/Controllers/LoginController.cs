using Microsoft.AspNetCore.Mvc;
using TestPractice.Data;
using TestPractice.Models;
using TestPractice.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly JwtService _jwtService;
        private readonly BirlaDBContext _dbContext;

        public LoginController(JwtService jwtService, BirlaDBContext dbContext)
        {

            _jwtService = jwtService;
            _dbContext= dbContext;

        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] SignIn login)
        {

            // Replace with your actual user validation logic (don't store plain text passwords)
            if (!IsValidUser(login))
            {
                return Unauthorized();
            }
            var user = GetUserFromCredentials(login); // Replace with logic to get user object
            var token = _jwtService.GenerateToken(user);
            return Ok(new { token = token });
   }


        private bool IsValidUser(SignIn login)
         {

         var user= _dbContext.Users.Select(u => u.FirstName == login.Username && u.Password==login.Password);
            if(user == null)
            {
                return false;
            }

            // Replace this with your actual user validation logic (e.g., compare with a database)

            return true; //login.Username == "admin" && login.Password == "pass"; // Example (replace with real logic)

        }

        private User GetUserFromCredentials(SignIn login)

        {
            var user = _dbContext.Users.FirstOrDefault(u => u.FirstName == login.Username && u.Password == login.Password);
                
                //(from u in _dbContext.Users
                //       where u.FirstName == login.Username && u.Password== login.Password
                //       select u) as User;
                
          
            // Replace this with logic to retrieve the User object based on validated credentials.
         
            return user; // Example (replace with real logic)

        }



    }
}
