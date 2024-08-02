using Bombillo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bombillo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
