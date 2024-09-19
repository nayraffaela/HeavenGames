using Microsoft.AspNetCore.Mvc;
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


        public async Task<IActionResult> Index()
        {
            
            return View(_mapper.Map<IEnumerable<TicketViewModel>>(await _ticketRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
           

            var ticketViewModel = await ObterTicketEvent(id);
           
            if (ticketViewModel == null) return NotFound();

            return View(ticketViewModel);
        }

      

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
            if (id != ticketViewModel.Id)  return NotFound();
            var ticketatualização = await ObterTicketEvent(id);
            ticketatualização = await PopularEventos(ticketViewModel);
            ticketViewModel.Event = ticketatualização.Event;

            if (!ModelState.IsValid) return View(ticketViewModel);
            ticketatualização.BuyerName=ticketViewModel.BuyerName;
            ticketatualização.BuyerCPF=ticketViewModel.BuyerCPF;
            ticketatualização.Value = ticketViewModel.Value;
            ticketatualização.TicketType=ticketViewModel.TicketType;
            ticketatualização.PaymentMethod=ticketViewModel.PaymentMethod;
            await _ticketRepository.Alterar(_mapper.Map<Ticket>(ticketViewModel));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var ticketViewModel = await ObterTicketEvent(id);
                
            if (ticketViewModel == null) return NotFound();
            
            return View(ticketViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ticketViewModel = await ObterTicketEvent(id);
            if (ticketViewModel == null) return NotFound();
            
            await _ticketRepository.Remover(id);
            return RedirectToAction("Index");
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
