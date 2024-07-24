using Microsoft.AspNetCore.Mvc;
using TestPractice.Data;
using TestPractice.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly BirlaDBContext _birlaContext;
        public RegisterController(BirlaDBContext birlaContext)
        {
            _birlaContext = birlaContext;
        }

       // POST api/<RegisterController>
        [HttpPost]
        public ActionResult<User> Post(SignUp user)
        {
         
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _birlaContext.Users.Add(
                new User {FirstName=user.FirstName,
                    LastName = user.LastName,
                    Password =user.Password,ConfirmPassword=user.ConfirmPassword,
                    EmailId=user.EmailId,PhoneNumber=user.PhoneNumber,Role="Customer" });
            _birlaContext.SaveChanges();
            return Created();

        }

    }
}
