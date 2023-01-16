using Microsoft.AspNetCore.Mvc;
using ProjectDenomHome.Models;
using System.Diagnostics;

namespace ProjectDenomHome.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


    }
}