
using HavenGames.Business.Models;
using HavenGames.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HavenGames.App.Controllers
{
    public class EventsController : Controller
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = await _context.Events
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
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Imagem,Localization,Date")] Event createdEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(createdEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(createdEvent);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventFromDb = await _context.Events.FindAsync(id);
            if (eventFromDb == null)
            {
                return NotFound();
            }
            return View(eventFromDb);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,Imagem,Localization,Date")] Event editedEvent)
        {
            if (id != editedEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editedEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(editedEvent.Id))
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
            return View(editedEvent);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = await _context.Events
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
            var eventViewModel = await _context.Events.FindAsync(id);
            if (eventViewModel != null)
            {
                _context.Events.Remove(eventViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(Guid id)
        {
            return _context.Events.Any(e => e.Id == id);
        }

        //[HttpGet, ActionName("Tickets")]
        //public async Task<IActionResult> Tickets(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var jogo = await _context.Events.Include(t => t.Tickets)
        // .FirstOrDefaultAsync(m => m.Id == id);
        //    if (jogo == null)
        //    {
        //        return NotFound();
        //    }

        //    jogo.Tickets = jogo.Tickets ?? new List<Ticket>();

        //    return View(jogo);
        //}

        //// GET: Jogos/Personagems/5
        //[HttpGet, ActionName("CreateTicket")]
        //public async Task<IActionResult> GetCreateTicket(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var jogo = await _context.Events
        //              .FirstOrDefaultAsync(m => m.Id == id);

        //    if (jogo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(event);
        //}

        //// POST: Jogos/Personagens/5
        //[HttpPost, ActionName("CreateTickets")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateTickets(Guid id, Ticket ticket)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            ticket.Id = Guid.NewGuid();

        //            var jogo = _context.Jogos.Include(t => t.Personagens)
        //                .FirstOrDefault(j => j.Id == id);

        //            if (jogo == null)
        //            {
        //                return NotFound();
        //            }

        //            jogo.Personagens.Add(ticket);


        //            _context.Add(ticket);
        //            _context.Update(jogo);

        //            _context.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EventExists(ticket.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("Personagens");
        //    }

        //    return View(ticket);
        //}

    }
}
