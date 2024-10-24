using AutoMapper;
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
        private readonly IMapper _mapper;

        public HomeController(ICommentRepository commentRepository,
            ICommentService commentService, IMapper mapper)

        {
            _commentRepository = commentRepository;
            _commentService = commentService;
            _mapper = mapper;
        }

        
        public async Task<IActionResult> IndexAsync()
        {

            var comments = await _commentRepository.ObterTodos();

            //instancia de homeviewmodel, estou atribuindo os comentários recuperados a Comments
            var viewModel = new HomeViewModel { Comments = comments };

            return View(viewModel);
        }

        //inclui aqui o atributo para que a msg de erro nao seja guardado em cache.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        

        // POST: Jogos/Personagens/5
        [HttpPost, ActionName("CreateComment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(CommentViewModel commentViewModel)
        {
            if (ModelState.IsValid)
            {
                var comment = _mapper.Map<Comment>(commentViewModel);
                comment.Id = Guid.NewGuid();

                await _commentService.Adicionar(comment);

                TempData["SuccessMessage"] = "Comentário adicionado com sucesso.";
            }
            else
            {
                TempData["ErrorMessage"] = "Erro ao adicionar o comentário.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("DeleteComment")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var comment = (await _commentRepository.Buscar(c => c.Id == id)).FirstOrDefault();

            if (comment == null) return NotFound();
            
            await _commentService.DeleteComment(comment);
            
            TempData["Sucesso"] = "Comentário excluído com sucesso.";
            
            return RedirectToAction("Comment");
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

        [Route("página-privacidade-politicas")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("página-sobre-nós")]
        public IActionResult AboutUs()
        {
            return View();
        }

        [Route("pagina-dicas-jogo")]
        public IActionResult Guide()
        {
            return View();
        }

        public IActionResult Events()
        {
            return View();
        }

        [Route("pagina-envio-curriculo")]
        public IActionResult Curriculum()
        {
            return View();
        }

        [Route("pagina-perguntas-frequentes")]
        public IActionResult FAQ()
        {
            return View();
        }

        [Route("pagina-envio-contato")]
        public IActionResult Contato()
        {
            return View();
        }

        [Route("pagina-cadastro-revistaeletronica")]
        public IActionResult Newsletter()
        {
            return View();
        }
    }
}
