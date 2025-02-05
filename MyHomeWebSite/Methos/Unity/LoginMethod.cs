using Microsoft.EntityFrameworkCore;
using MyHomeWebSite.Controllers;
using MyHomeWebSite.Models;
using System.ComponentModel.DataAnnotations;

namespace MyHomeWebSite.Methods
{
    public class LoginMethod
    {
        private readonly MyDBContext _dbContext;

        public LoginMethod(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        async public Task<bool> ValidLogin(Login login)
        {
            try
            {
                if (!string.IsNullOrEmpty(login.Identity))
                {
                    switch (login.Identity)
                    {
                        case "admin":
                            login.Account = "Admin";
                            break;
                        case "manager":
                            login.Account = "Manager";
                            break;
                        case "user":
                            Random random = new Random();
                            login.Account = "User" + random.Next(1, 4);
                            break;
                        default:
                            return false;
                    }
                    string aa = "";

                    login.PassWord = "123";
                }
                return await _dbContext.Adata.AnyAsync(l => l.Account == login.Account && l.PassWord == login.PassWord);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
