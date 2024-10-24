using AutoMapper;
using HavenGames.App.ViewModels;
using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HavenGames.App.Controllers
{
    public class EventsController : BaseController
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventsController(IEventRepository eventRepository, 
                                IEventService eventService, 
                                IMapper mapper, INotificador notificador): base(notificador)
        {
            _eventRepository = eventRepository;
            _eventService = eventService;
            _mapper = mapper;
        }

        [Route("lista-de-eventos")]

        public async Task<IActionResult> Index()
        {
            var events = await _eventRepository.ObterTodos();
            var eventViewModels = _mapper.Map<IEnumerable<EventViewModel>>(events);
            return View(eventViewModels);
        }

        [Route("novo-evento")]

        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-evento")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                var evento = _mapper.Map<Event>(eventViewModel);
                await _eventService.Adicionar(evento);
                if (!IsOperacaoValida())
                {
                    TempData["Erro"] = "Já existe um evento cadastrado com o nome informado.";
                    return View(eventViewModel);
                }

                TempData["Sucesso"] = "Evento cadastrado com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            return View(eventViewModel);
        }

        [Route("editar-evento/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var evento = await _eventRepository.ObterPorId(id);
            if (evento == null)
            {
                return NotFound();
            }

            var eventViewModel = _mapper.Map<EventViewModel>(evento);
            return View(eventViewModel);
        }

        [Route("editar-evento/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EventViewModel eventViewModel)
        {
            if (id != eventViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var evento = _mapper.Map<Event>(eventViewModel);
                await _eventService.Alterar(evento);
                if (!IsOperacaoValida()) return View(eventViewModel);

                TempData["Sucesso"] = "Evento editado com sucesso!";


                return RedirectToAction(nameof(Index));
            }
            return View(eventViewModel);
        }

        [Route("excluir-evento/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var evento = await _eventRepository.ObterPorId(id);
            if (evento == null)
            {
                return NotFound();
            }

            var eventViewModel = _mapper.Map<EventViewModel>(evento);
            return View(eventViewModel);
        }


        [Route("excluir-evento/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var eventoExiste = await EventExistsAsync(id);
            if (eventoExiste)
            {
                await _eventService.Remover(id);

                if (!IsOperacaoValida()) return View();

                TempData["Sucesso"] = "Evento excluído com sucesso!";

            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EventExistsAsync(Guid id)
        {
            var evento = await _eventRepository.Buscar(e => e.Id == id);
            return evento.FirstOrDefault() != null;
        }
    }
}