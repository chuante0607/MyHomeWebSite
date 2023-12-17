using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHomeWebSite.Models;

namespace MyHomeWebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly MyDBContext _dbContext;
        public LoginController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        /// <summary>
        /// µn§J≈Á√“
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            login.ValidIdentity();
            var result = await _dbContext.Adata.FirstOrDefaultAsync(l => l.Account == login.Account && l.PassWord == login.PassWord);
            if (result == null)
            {
                return Unauthorized(login);
            }
            return Ok(new { Id = result.UserId, Url = "/WebPages/Index.Html" });
        }
    }

    public class Login
    {
        public string? Account { get; set; }
        public string? PassWord { get; set; }
        public string? Identity { get; set; }
        public string? UserId { get; set; }
        public void ValidIdentity()
        {
            if (!string.IsNullOrEmpty(this.Identity))
            {
                switch (this.Identity)
                {
                    case "admin":
                        this.Account = "Admin";
                        this.PassWord = "123";
                        break;
                    case "manager":
                        this.Account = "Manager";
                        this.PassWord = "123";
                        break;
                    case "user":
                        Random random = new Random();
                        this.Account = "User" + random.Next(19);
                        this.PassWord = "123";
                        break;
                    default:
                        break;
                }
            }
        }
    }
}