
using HavenGames.Business.Models;
using HavenGames.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HavenGames.App.Controllers
{
    public class JogosController : Controller
    {
        private readonly AppDbContext _context;

        public JogosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Jogos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jogos.ToListAsync());
        }

        // GET: Jogos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        // GET: Jogo/Create
        public IActionResult Create()
        {
            ViewBag.Personagens = _context.Personagens.ToList(); // Carrega todos os personagens disponíveis
            return View(); 
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Plataforma,Genero,Imagem")] Jogo jogo, int[] selectedPersonagens)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogo);

                // Adicionar personagens ao jogo
                if (selectedPersonagens != null)
                {
                    foreach (var personagemId in selectedPersonagens)
                    {
                        var personagem = await _context.Personagens.FindAsync(personagemId);
                        if (personagem != null)
                        {
                            personagem.Jogo = jogo;
                            jogo.Personagens.Add(personagem);
                            _context.Personagens.Update(personagem);
                        }
                    }
                }
                    
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Personagens = await _context.Personagens.ToListAsync();
            return View(jogo);
        }

        // GET: Jogos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos
             .Include(j => j.Personagens)
             .FirstOrDefaultAsync(j => j.Id == id);

            if (jogo == null)
            {
                return NotFound();
            }
            return View(jogo);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Plataforma,Genero,Imagem")] Jogo jogo, int[] selectedPersonagens)
        {
            if (id != jogo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogo);

                    // Atualizar personagens associados
                    var personagensExistentes = _context.Personagens.Where(p => p.Jogo.Id == id).ToList();
                   
                    foreach (var personagem in personagensExistentes)
                    {
                        personagem.Jogo = null;
                        _context.Personagens.Update(personagem);
                    }

                    foreach (var personagemId in selectedPersonagens)
                    {
                        var personagem = await _context.Personagens.FindAsync(personagemId);
                        if (personagem != null)
                        {
                            personagem.Jogo = jogo;
                            _context.Personagens.Update(personagem);
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogoExists(jogo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Personagens = await _context.Personagens.ToListAsync();
            return View(jogo);
        }

        // GET: Jogos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo != null)
            {
                _context.Jogos.Remove(jogo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogoExists(Guid id)
        {
            return _context.Jogos.Any(e => e.Id == id);
        }
    }
}
