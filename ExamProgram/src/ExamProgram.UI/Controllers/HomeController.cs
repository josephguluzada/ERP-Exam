using ExamProgram.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamProgram.UI.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(ILogger<HomeController> logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
