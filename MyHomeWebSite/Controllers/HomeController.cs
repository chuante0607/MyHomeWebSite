using Microsoft.AspNetCore.Mvc;

namespace MyHomeWebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(Login user)
        {
            return Ok();
        }
    }
}
