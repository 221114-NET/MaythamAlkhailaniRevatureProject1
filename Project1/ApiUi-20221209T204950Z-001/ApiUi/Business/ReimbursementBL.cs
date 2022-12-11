using ApiUi.Models.Data;
using ApiUi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ApiUi.Business
{
    public interface IReimbursementBL
    {
        Task Add(ReimbursementList reimbursementList);
        Task<ReimbursementList?> Get(Guid id);
        Task<List<ReimbursementList>> GetAll();
        Task<bool> Update(ReimbursementList reimbursementList, UpdateReimbursementList updateReimbursementList);
    }

    public class ReimbursementBL : IReimbursementBL
    {
        private readonly P1dbContext _dbContext;
        public ReimbursementBL(P1dbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task Add(ReimbursementList reimbursementList)
        {
            _dbContext.ReimbursementLists.Add(reimbursementList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(ReimbursementList reimbursementList, UpdateReimbursementList updateReimbursementList)
        {
            if (reimbursementList != null)
            {
                reimbursementList.Status = updateReimbursementList.Status;
                reimbursementList.Name = updateReimbursementList.Name;
                reimbursementList.Email = updateReimbursementList.Email;
                reimbursementList.TimeOff = updateReimbursementList.TimeOff;
                reimbursementList.BusinessTravelCost = updateReimbursementList.BusinessTravelCost;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ReimbursementList?> Get(Guid id)
        {
            return await _dbContext.ReimbursementLists.FindAsync(id);
        }

        public async Task<List<ReimbursementList>> GetAll()
        {
            return await _dbContext.ReimbursementLists.ToListAsync();

        }
    }
}
