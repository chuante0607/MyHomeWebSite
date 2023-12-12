using Microsoft.AspNetCore.Mvc;

namespace DemoProj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>() { "Hello World" };
        }
    }
}