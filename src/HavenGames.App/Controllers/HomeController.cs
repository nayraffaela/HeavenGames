using HavenGames.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
   
namespace HavenGames.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
      
        public IActionResult Guide()
        {
            return View();
        }
        public IActionResult Events()
        {
            return View();
        }
        public IActionResult Resenhas()
        {
            return View();
        }

    }
 }
