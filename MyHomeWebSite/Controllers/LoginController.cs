using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHomeWebSite.Methods;
using MyHomeWebSite.Models;

namespace MyHomeWebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginMethod _loginMethod;

        public LoginController(LoginMethod loginMethod)
        {
            _loginMethod = loginMethod;
        }

        /// <summary>
        /// µn§J≈Á√“
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            bool validResult = await _loginMethod.ValidLogin(login);
            if (validResult)
            {
                return RedirectToAction("Index", "Home", login);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}