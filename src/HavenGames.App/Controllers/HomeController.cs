using HavenGames.App.Models;
using HavenGames.App.ViewModels;
using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HavenGames.App.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ICommentService _commentService;


        public HomeController(ICommentRepository commentRepository, ICommentService commentService)

        {
            _commentRepository = commentRepository;
            _commentService = commentService;
        }

        public async Task<IActionResult> IndexAsync()
        {

            var comments = await _commentRepository.ObterTodos();

            var viewModel = new HomeViewModel { Comments = comments };

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // POST: Jogos/Personagens/5
        [HttpPost, ActionName("CreateComment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Id = Guid.NewGuid();
                await _commentService.Adicionar(comment);
                TempData["SuccessMessage"] = "Comentário adicionado com sucesso.";
            }
            else
            {
                TempData["ErrorMessage"] = "Erro ao adicionar o comentário.";
            }

            return RedirectToAction("IndexAsync");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var result = await _commentService.DeleteComment(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Comentário excluído com sucesso.";
            }
            else
            {
                TempData["ErrorMessage"] = "Erro ao excluir o comentário.";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Comment()
        {
            var comments = await _commentService.ObterTodos(); 
            var viewModel = new HomeViewModel
            {
                Comments = comments
            };

            return View(comments);
        }

        public IActionResult Privacy()
        {
            return View();
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
        public IActionResult Curriculum()
        {
            return View();
        }
    }
}
