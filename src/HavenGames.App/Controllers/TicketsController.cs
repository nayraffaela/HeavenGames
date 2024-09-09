using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HavenGames.App.Data;
using HavenGames.App.ViewModels;
using HavenGames.Business.Interfaces;
using AutoMapper;
using HavenGames.Business.Models;

namespace HavenGames.App.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;




        public TicketsController(ITicketRepository ticketRepository, IEventRepository eventRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            
            return View(_mapper.Map<IEnumerable<TicketViewModel>>(await _ticketRepository.ObterTodos()));
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
           

            var ticketViewModel = await ObterTicketEvent(id);
           
            if (ticketViewModel == null) return NotFound();

            return View(ticketViewModel);
        }

      

        // GET: Tickets/Create
        public async Task <IActionResult> Create()
        {
            var ticketViewModel = await PopularEventos(new TicketViewModel());
            return View();
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( TicketViewModel ticketViewModel)
        {
            if (!ModelState.IsValid) return View(ticketViewModel);
            await _ticketRepository.Adicionar(_mapper.Map<Ticket>(ticketViewModel));
            return RedirectToAction("Index");

        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {

            var ticketViewModel = await ObterTicketEvent(id);
            ticketViewModel = await PopularEventos(ticketViewModel);

            if (ticketViewModel == null) return NotFound();
           
            return View(ticketViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,  TicketViewModel ticketViewModel)
        {
            if (id !=ticketViewModel.Id) return NotFound();
            var ticketatualização = await ObterTicketEvent(id);
          
            if (!ModelState.IsValid) return View(ticketViewModel);
         
            return RedirectToAction("Index");
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketViewModel = await 
                .Include(t => t.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketViewModel == null)
            {
                return NotFound();
            }

            return View(ticketViewModel);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketViewModel = await 
            if (ticketViewModel != null)
            {
                
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketViewModelExists(int id)
        {
            return _context.TicketViewModel.Any(e => e.Id == id);
        }

        private async Task<TicketViewModel> ObterTicketEvent(Guid id)
        {
            return _mapper.Map<TicketViewModel>(await _ticketRepository.ObterPorId(id));
        }
        private async Task <TicketViewModel> PopularEventos(TicketViewModel ticketViewModel)
        {
            ticketViewModel.Events = _mapper.Map<IEnumerable<EventViewModel>>(await _eventRepository.ObterTodos());
            return ticketViewModel;
        }
    }
}
