using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HavenGames.App.Controllers
{
    public class GuideController : Controller
    {
        public IActionResult AssassinCreed()
        {
            return View();
        }
        
        public IActionResult GTAV()
        {
            return View();
        }
        
        public IActionResult RedDead()
        {
            return View();
        }
        
        public IActionResult TheElder()
        {
            return View();
        }
        
        public IActionResult TheLastOfUs()
        {
            return View();
        }

        public IActionResult TheOrder()
        {
            return View();
        }
    }
}
