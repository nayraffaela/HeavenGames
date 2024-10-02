
using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HavenGames.App.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventService _eventService;

        public EventsController(IEventRepository eventRepository, IEventService eventService)
        {
            _eventRepository = eventRepository;
            _eventService = eventService;
        }

        
        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(await _eventRepository.ObterTodos());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
           
            var eventViewModel = await _eventRepository.ObterPorId(id);
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
                await _eventService.Adicionar(createdEvent);
                return RedirectToAction(nameof(Index));
            }
            return View(createdEvent);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
         
            var eventFromDb = await _eventRepository.ObterPorId(id);
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
                   await _eventService.Alterar(editedEvent);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await EventExistsAsync(editedEvent.Id))
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
        public async Task<IActionResult> Delete(Guid id)
        {
            

            var evento = await _eventRepository.ObterPorId(id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var evento = await _eventRepository.ObterPorId(id);

            if (evento != null)
            {
                await _eventService.Remover(evento);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EventExistsAsync(Guid id)
        {
            var evento = await _eventRepository.ObterPorId(id);
            return evento != null;
        }

    

    }
}
