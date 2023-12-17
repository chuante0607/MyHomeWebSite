using Microsoft.EntityFrameworkCore;
using MyHomeWebSite.Models;

namespace MyHomeWebSite.Methos
{
    public class UserMethod
    {
        private readonly MyDBContext _dbContext;

        public UserMethod(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        async public Task<Aemployee> GetUser(Login login)
        {
            try
            {
                var user = await _dbContext.Adata
                    .Join(_dbContext.Aemployees, a => a.UserId, b => b.UserId, (a, b) => new { Login = a, Employee = b })
                    .FirstAsync(l => l.Login.Account == login.Account && l.Login.PassWord == login.PassWord);

                return user.Employee;
            }
            catch (Exception ex)
            {
                return new Aemployee();
            }
        }
    }
}
