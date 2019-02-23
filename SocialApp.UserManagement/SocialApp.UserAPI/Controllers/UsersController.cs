using SocialApp.Core.Services;
using SocialApp.Data;
using SocialApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace SocialApp.Core.Controllers
{
    [Produces("application/json")]
    [Route("api/auth/users")]
    public class UsersController : Controller
    {
        private readonly IUsersServices _userServices;

        public UsersController(GoingOutContext context)
        {
            _userServices = new UsersService(context);
        }

        [HttpGet("{id:int}", Name = "GetId")]
        public IActionResult Get(int id)
        {
            User user = _userServices.GetById(id);

            return Ok(user);
        }

        [HttpGet("{userName}", Name = "GetByName")]
        //public IActionResult GetByName(string userName)
        public IActionResult GetByName2(string userName)
        {
            User user = _userServices.Get(userName);

            Response.StatusCode = 200;
            return Ok(user);
        }
        [HttpPost]
        public IActionResult GetByName([FromBody] UserQuery model)
        {
            User user = _userServices.Get(model.UserName);

            Response.StatusCode = 200;
            return Ok(user);
        }

        public class UserQuery
        {
            public string UserName { get; set; }
        }
        
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                user = _userServices.CreateUser(user);

                return Ok(user);
            }
            Response.StatusCode = 200;
            return BadRequest("User is not well introduced");
        }

        [HttpDelete(Name = "DeleteUser")]
        public IActionResult DeleteUser(int userId)
        {
            User user = _userServices.DeleteUser(userId);

            return Ok(user);
        }
    }
}
