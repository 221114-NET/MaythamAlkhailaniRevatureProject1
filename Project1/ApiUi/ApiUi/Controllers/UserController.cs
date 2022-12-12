using ApiUi.Business;
using ApiUi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiUi.Controllers
{
    [ApiController]
    [Route("api/controller/Register/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;

        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUser addUser)
        {

            User user = new User()

            {
                Name = addUser.name,
                Email = addUser.email,
                Password = addUser.password
            };
            await _userBL.Add(user);

            return Ok(user);

        }


    }

}

