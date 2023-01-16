using Microsoft.AspNetCore.Mvc;

namespace ProjectDenomHome.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
