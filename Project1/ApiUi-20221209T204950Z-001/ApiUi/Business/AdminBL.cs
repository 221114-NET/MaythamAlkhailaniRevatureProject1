using ApiUi.Models.Data;
using ApiUi.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiUi.Business
{
    public interface IAdminBL
    {
        Task Add(Admin admin);
        Task<bool> Verify(string email, string password);
    }

    public class AdminBL : IAdminBL
    {
        private readonly P1dbContext _dbContext;
        public AdminBL(P1dbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task Add(Admin admin)
        {
            _dbContext.Admins.Add(admin);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Verify(string email, string password)

        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    return false;
                }
                else
                {
                    return (await _dbContext.Admins.Where(x => x.Email.Equals(email) && x.Password.Equals(password)).CountAsync()) > 0;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
