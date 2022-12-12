using ApiUi.Business;
using ApiUi.Models;
using ApiUi.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiUi.Controllers
{

    [ApiController]
    [Route("api/ReimbursementList")]
    public class ReimbursementListController : Controller
    {
        private readonly IUserBL _userBL;
        private readonly IAdminBL _adminBL;
        private readonly IReimbursementBL _reimbursementBL;

        public ReimbursementListController(IUserBL userBL, IAdminBL adminBL, IReimbursementBL reimbursementBL)
        {
            _userBL = userBL;
            _adminBL = adminBL;
            _reimbursementBL = reimbursementBL;
        }

        [HttpGet]
        public async Task<IActionResult> GetReimbursementList()
        {
            return Ok(await _reimbursementBL.GetAll());

        }

        [HttpPost]

        public async Task<IActionResult> AddReimbursement([FromQuery] string email, [FromQuery] string password, [FromBody] AddReimbursement addReimbursement)
        {


            bool isVerified = await _userBL.Verify(email, password);
            if (!isVerified)
            {
                return Unauthorized();
            }
            var reimbursementList = new ReimbursementList()
            {
                Id = Guid.NewGuid(),
                Name = addReimbursement.Name,
                Email = addReimbursement.Email,
                TimeOff = addReimbursement.TimeOff,
                BusinessTravelCost = addReimbursement.BusinessTravelCost,
                Status = addReimbursement.Status,

            };

            await _reimbursementBL.Add(reimbursementList);
            return Ok(reimbursementList);




        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateReimbursement([FromRoute] Guid id, [FromQuery] string email, [FromQuery] string password, [FromBody] UpdateReimbursementList updateReimbursementList)
        {
            bool isVerified = await _adminBL.Verify(email, password);
            if (!isVerified)
            {
                return Unauthorized();
            }

            var reimbursementList = await _reimbursementBL.Get(id);
            if (reimbursementList != null)
            {
                await _reimbursementBL.Update(reimbursementList, updateReimbursementList);
                return Ok(reimbursementList);
            }

            return NotFound();

        }
    }
}