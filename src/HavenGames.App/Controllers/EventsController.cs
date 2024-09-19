
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using HavenGames.App.Data;
using HavenGames.App.ViewModels;


namespace HavenGames.App.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventViewModel.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = await _context.EventViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventViewModel == null)
            {
                return NotFound();
            }

            return View(eventViewModel);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Date")] EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventViewModel);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = await _context.EventViewModel.FindAsync(id);
            if (eventViewModel == null)
            {
                return NotFound();
            }
            return View(eventViewModel);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Date")] EventViewModel eventViewModel)
        {
            if (id != eventViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventViewModelExists(eventViewModel.Id))
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
            return View(eventViewModel);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = await _context.EventViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventViewModel == null)
            {
                return NotFound();
            }

            return View(eventViewModel);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventViewModel = await _context.EventViewModel.FindAsync(id);
            if (eventViewModel != null)
            {
                _context.EventViewModel.Remove(eventViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventViewModelExists(int id)
        {
            return _context.EventViewModel.Any(e => e.Id == id);
        }

        
    }
}
