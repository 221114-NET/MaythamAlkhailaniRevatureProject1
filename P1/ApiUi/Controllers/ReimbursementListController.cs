using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUi.Models;
using ApiUi.Models.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiUi.Controllers
{

    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/ReimbursementList")]
    public class ReimbursementListController : Controller


    {
        //So I can use the dbContext to talk to my inmemory database.
        private readonly P1dbContext dbContext; 
        public ReimbursementListController (P1dbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        [HttpGet]
        public async Task <IActionResult> GetReimbursementList()
        {
            return Ok (await dbContext.ReimbursementLists.ToListAsync());
            
        }  
        [HttpPost]
        public async Task <IActionResult> AddReimbursement(AddReimbursement addReimbursement )
        {

            //New Opject and assgin values. 
            //We are mapping between AddReimbursement ReimbursementList.
            //This is what goes into the dbContext/database
            var reimbursementList = new ReimbursementList() 
            {
                    
                    Id =Guid.NewGuid(),

                    Name = addReimbursement.Name,
                    Email = addReimbursement.Email,
                    TimeOff = addReimbursement.TimeOff,
                    BusinessTravelCost = addReimbursement.BusinessTravelCost,
                    Status = addReimbursement.Status,

            };

            await dbContext.ReimbursementLists.AddAsync(reimbursementList);
            await dbContext.SaveChangesAsync();
            return Ok(reimbursementList);

              


        }  

        [HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("{id:guid}")]
        public async Task<IActionResult>UpdateReimbursement([FromRoute] Guid id, UpdateReimbursementList updateReimbursementList)
        {
            var reimbursementList =  await dbContext.ReimbursementLists.FindAsync(id);
            if (reimbursementList != null)
            {   
                reimbursementList.Status = updateReimbursementList.Status;
                reimbursementList.Name = updateReimbursementList.Name;
                reimbursementList.Email = updateReimbursementList.Email;
                reimbursementList.TimeOff = updateReimbursementList.TimeOff;
                reimbursementList.BusinessTravelCost = updateReimbursementList.BusinessTravelCost;

                await dbContext.SaveChangesAsync();
                return Ok(reimbursementList);
            }

            return NotFound();

        }
    }
}