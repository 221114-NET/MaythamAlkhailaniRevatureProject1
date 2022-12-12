using ApiUi.Models;
using ApiUi.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiUi.Business
{
    public interface IUserBL
    {
        Task Add(User user);
        Task<bool> Verify(string email, string password);
    }

    public class UserBL : IUserBL
    {
        private readonly P1dbContext _dbContext;
        public UserBL(P1dbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task Add(User user)
        {
            _dbContext.Users.Add(user);
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
                    return (await _dbContext.Users.Where(x => x.Email.Equals(email) && x.Password.Equals(password)).CountAsync()) > 0;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
