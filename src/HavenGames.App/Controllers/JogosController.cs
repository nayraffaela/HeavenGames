
using AutoMapper;
using HavenGames.App.ViewModels;
using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace HavenGames.App.Controllers
{
    public class JogosController : Controller
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly IJogoService _jogoService;
        private readonly IMapper _mapper;

        public JogosController(IJogoRepository jogoRepository, 
                                IJogoService jogoService,
                                IMapper mapper)
        {
            _jogoRepository = jogoRepository;
            _jogoService = jogoService;
            _mapper = mapper;

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
        public async Task<IActionResult> Create(JogoViewModel jogoViewModel)
        {
            if (ModelState.IsValid) return View(jogoViewModel);
            
            await _jogoService.Adicionar(_mapper.Map<Jogo>(jogoViewModel));

            //addnotificador e msg tempdata
            return RedirectToAction(nameof(Index));

        }

        // GET: Jogos/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var jogoViewModel = await ObterJogoPersonagens(id);
           
            if (jogoViewModel == null) return NotFound();

            return View(jogoViewModel);
        }

        // POST: Jogos/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, JogoViewModel jogoViewModel)
        {
            if (id != jogoViewModel.Id) return NotFound();
            
            if (!ModelState.IsValid) return View(jogoViewModel);
            
            var jogo = _mapper.Map<Jogo>(jogoViewModel);
            
            await _jogoService.Alterar(jogo);

            return RedirectToAction(nameof(Index));
            

            
        }

        // GET: Jogos/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var jogoViewModel = await ObterJogoPersonagens(id);

            if (jogoViewModel == null) return NotFound();
            
            return View(jogoViewModel);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var jogoViewModel = await ObterJogoPersonagens(id);

            if (jogoViewModel == null) return NotFound();
            
            await _jogoService.Remover(id);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Jogos/Personagens/5
        [HttpGet, ActionName("Personagens")]
        public async Task<IActionResult> Personagens(Guid id)
        {
            var jogo = await ObterJogoPersonagens(id);
            return View(jogo);
        }

        // GET: Jogos/Personagems/5
        [HttpGet, ActionName("CreatePersonagem")]
        public async Task<IActionResult> GetCreatePersonagem(Guid id)
        {
            var jogoViewModel = await ObterJogoPersonagens(id);

            if (jogoViewModel == null) return NotFound();

            var personagemViewModel = new PersonagemViewModel() { };
            personagemViewModel.Jogo = jogoViewModel;

            return View(personagemViewModel);
        }



        // POST: Jogos/Personagens/5
        [HttpPost, ActionName("CreatePersonagem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePersonagem(Guid jogoId, PersonagemViewModel personagemViewModel)
        {
            if (ModelState.IsValid) return View(personagemViewModel);

            var personagem = _mapper.Map<Personagem>(personagemViewModel);
            personagem.Id = Guid.NewGuid();

            var jogo = await _jogoRepository.ObterJogoComPersonagens(jogoId);

            await _jogoService.AdicionarPersonagem(jogo, personagem);

            return RedirectToAction("Personagens", jogo);

        }

        // GET: Jogos/UpdatePersonagem/5
        [HttpGet, ActionName("UpdatePersonagem")]
        public async Task<IActionResult> UpdatePersonagem(Guid jogoId, Guid personagemId)
        {
            var jogoViewModel = await ObterJogoPersonagens(jogoId);

            if (jogoViewModel == null) return NotFound();

            var personagem = jogoViewModel.Personagens.FirstOrDefault(p => p.Id == personagemId);

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
                existingPersonagem.Imagem = personagem.Imagem;

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

        private async Task<JogoViewModel> ObterJogo(Guid id)
        {
            return _mapper.Map<JogoViewModel>(await _jogoRepository.ObterPorId(id));
        }

        private async Task<JogoViewModel> ObterJogoPersonagens(Guid id)
        {
            return _mapper.Map<JogoViewModel>(await _jogoRepository.ObterJogoComPersonagens(id));
        }

    }
}
