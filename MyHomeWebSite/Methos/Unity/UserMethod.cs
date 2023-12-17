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

        /// <summary>
        /// 取得User資料
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 取得User清單
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        async public Task<List<Aemployee>> GetUsers()
        {
            try
            {
                return await _dbContext.Aemployees.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        async public Task<List<Aemployee>> UpdateUser(User user)
        {
            try
            {
                var data = await _dbContext.Aemployees.FirstOrDefaultAsync(d => d.UserId == user.UserId);
                if (data != null)
                {
                    data.Avatar = user.Avatar;
                    _dbContext.SaveChanges();
                }
                return await GetUsers();
            }
            catch (Exception ex)
            {
                return new List<Aemployee>();
            }
        }

    }
}
