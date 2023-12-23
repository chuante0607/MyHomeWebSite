using Microsoft.AspNetCore.Mvc;
using MyHomeWebSite.Methods;
using MyHomeWebSite.Models;

namespace MyHomeWebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly UserMethod _userMethod;


        public HomeController(UserMethod userMethod)
        {
            _userMethod = userMethod;
        }


        [HttpGet]
        async public Task<IActionResult> Index([FromQuery] Login login)
        {
            Aemployee employee = await _userMethod.GetUser(login);
            return Ok(new { Url = "/WebPages/Index.Html", Employee = employee });
        }

        [HttpPost]
        async public Task<List<Aemployee>> Index()
        {
            return await _userMethod.GetUser();
        }

        [HttpPut]
        async public Task<List<Aemployee>> Index([FromBody] User user)
        {
            return await _userMethod.UpdateUser(user);
        }
    }
}
