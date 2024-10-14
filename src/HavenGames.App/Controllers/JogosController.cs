
using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HavenGames.App.Controllers
{
    public class JogosController : Controller
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly IJogoService _jogoService;

        public JogosController(IJogoRepository jogoRepository, IJogoService jogoService)
        {
            _jogoRepository = jogoRepository;
            _jogoService = jogoService;
        }

        // GET: Jogos
        public async Task<IActionResult> Index()
        {
            var jogos = await _jogoRepository.ObterTodos();

            return View(jogos);
        }

        // GET: Jogos/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var jogo = await _jogoRepository.ObterPorId(id);

            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }



        // GET: Jogo/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jogos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Plataforma,Genero,Imagem, Descricao")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                await _jogoService.Adicionar(jogo);

                return RedirectToAction(nameof(Index));
            }

            return View(jogo);
        }

        // GET: Jogos/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var jogo = await _jogoRepository.ObterPorId(id);

            return View(jogo);
        }

        // POST: Jogos/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Plataforma,Genero,Imagem, Descricao")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                await _jogoService.Alterar(jogo);

                return RedirectToAction(nameof(Index));
            }

            return View(jogo);
        }

        // GET: Jogos/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var jogo = await _jogoRepository.ObterPorId(id);

            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var jogo = await _jogoRepository.ObterJogoComPersonagens(id);

            if (jogo != null)
            {
                await _jogoService.Remover(jogo);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Jogos/Personagens/5
        [HttpGet, ActionName("Personagens")]
        public async Task<IActionResult> Personagens(Guid id)
        {
            var jogo = await _jogoRepository.ObterJogoComPersonagens(id);

            jogo.Personagens = jogo?.Personagens ?? new List<Personagem>();

            return View(jogo);
        }

        // GET: Jogos/Personagems/5
        [HttpGet, ActionName("CreatePersonagem")]
        public async Task<IActionResult> GetCreatePersonagem(Guid id)
        {
            var jogo = await _jogoRepository.ObterPorId(id);

            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }



        // POST: Jogos/Personagens/5
        [HttpPost, ActionName("CreatePersonagem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePersonagem(Guid id, Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                personagem.Id = Guid.NewGuid();

                var jogo = await _jogoRepository.ObterJogoComPersonagens(id);

                if (jogo == null)
                {
                    return NotFound();
                }

                await _jogoService.AdicionarPersonagem(jogo, personagem);

                return RedirectToAction("Personagens", jogo);
            }

            return View(personagem);
        }

        // GET: Jogos/UpdatePersonagem/5
        [HttpGet, ActionName("UpdatePersonagem")]
        public async Task<IActionResult> UpdatePersonagem(Guid jogoId, Guid personagemId)
        {
            var jogo = await _jogoRepository.ObterJogoComPersonagens(jogoId);

            if (jogo == null)
            {
                return NotFound();
            }

            var personagem = jogo.Personagens.FirstOrDefault(p => p.Id == personagemId);

            if (personagem == null)
            {
                return NotFound();
            }

            ViewData["JogoId"] = jogoId;
            return View("UpdatePersonagem", personagem);
        }


        // POST: Jogos/UpdatePersonagem/5
        [HttpPost, ActionName("UpdatePersonagem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePersonagem(Guid jogoId, Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                var jogo = await _jogoRepository.ObterJogoComPersonagens(jogoId);

                if (jogo == null)
                {
                    return NotFound();
                }

                var existingPersonagem = jogo.Personagens.FirstOrDefault(p => p.Id == personagem.Id);

                if (existingPersonagem == null)
                {
                    return NotFound();
                }

                existingPersonagem.Nome = personagem.Nome;
                existingPersonagem.Descricao = personagem.Descricao;

                await _jogoService.AlterarPersonagem(existingPersonagem);

                return RedirectToAction(nameof(Personagens), jogo);
            }

            return View("EditPersonagem", personagem);
        }


        // GET: Jogos/DeletePersonagem/5
        [HttpGet, ActionName("DeletePersonagem")]
        public async Task<IActionResult> DeletePersonagem(Guid jogoId, Guid personagemId)
        {
            var jogo = await _jogoRepository.ObterJogoComPersonagens(jogoId);

            if (jogo == null)
            {
                return NotFound();
            }

            var personagem = jogo.Personagens.FirstOrDefault(p => p.Id == personagemId);
            if (personagem == null)
            {
                return NotFound();
            }

            return View(personagem);
        }

        // POST: Jogos/DeletePersonagem/5
        [HttpPost, ActionName("DeletePersonagem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePersonagemConfirmed(Guid jogoId, Guid personagemId)
        {
            var jogo = await _jogoRepository.ObterJogoComPersonagens(jogoId);

            if (jogo == null)
            {
                return NotFound();
            }

            var personagem = jogo.Personagens.FirstOrDefault(p => p.Id == personagemId);
            if (personagem != null)
            {

                await _jogoService.RemoverPersonagem(jogo, personagem);


            }

            return RedirectToAction(nameof(Personagens), jogo);
        }

    }
}
