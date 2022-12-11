using Microsoft.AspNetCore.Mvc;
using ApiUi.Business;
using ApiUi.Models;

namespace ApiUi.Controllers
{
    [ApiController]
    [Route("api/controller/Register/Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminBL _adminBL;

        public AdminController(IAdminBL adminBL)
        {
            _adminBL = adminBL;
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(AddUser addAdmin)
        {

            Admin admin = new Admin()

            {
                Name = addAdmin.name,
                Email = addAdmin.email,
                Password = addAdmin.password
            };
            await _adminBL.Add(admin);

            return Ok(admin);
        }
    }

}