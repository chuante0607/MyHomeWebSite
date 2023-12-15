using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyHomeWebSite.Models;

namespace MyHomeWebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly MyDBContext _dbContext;
        public HomeController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] Login login)
        {
            var result = await _dbContext.Adata.FirstOrDefaultAsync(f => f.Account == login.Account && f.PassWord == login.PassWord);

            if (result == null)
            {
                return Unauthorized(new { ErrorMsg = "查無此用戶" });
            }
            return Ok();
        }
    }

    public class Login
    {
        public string Account { get; set; }
        public string PassWord { get; set; }
    }
}