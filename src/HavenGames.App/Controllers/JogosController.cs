
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
        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        // POST: Jogos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Plataforma,Genero,Imagem")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogo);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(jogo);
        }

        // GET: Jogos/Edit/5
        [HttpGet]
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
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Plataforma,Genero,Imagem")] Jogo jogo)
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
