using Microsoft.AspNetCore.Mvc;

namespace MyHomeWebSite.Controllers
{
    public class ShoppingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
