using Microsoft.AspNetCore.Mvc;

namespace HavenGames.App.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
