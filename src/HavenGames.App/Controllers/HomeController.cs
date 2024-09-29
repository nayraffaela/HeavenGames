using HavenGames.App.Models;
using HavenGames.App.ViewModels;
using HavenGames.Business.Models;
using HavenGames.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HavenGames.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public async Task<IActionResult> IndexAsync()
        {

            var comments = await _context.Comments.ToListAsync();

            var viewModel = new HomeViewModel { Comments = comments };

            return View(viewModel);
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
        public IActionResult Curriculum()
        {
            return View();
        }

        // POST: Jogos/Personagens/5
        [HttpPost, ActionName("CreateComment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Id = Guid.NewGuid();

                _context.Add(comment);
                _context.SaveChanges();

            }

            return RedirectToAction("Index");
        }



    }
}
