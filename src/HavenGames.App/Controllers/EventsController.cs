﻿using AutoMapper;
using HavenGames.App.ViewModels;
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
        private readonly IMapper _mapper;

        public EventsController(IEventRepository eventRepository, IEventService eventService, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _eventService = eventService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventRepository.ObterTodos();
            var eventViewModels = _mapper.Map<IEnumerable<EventViewModel>>(events);
            return View(eventViewModels);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                var evento = _mapper.Map<Event>(eventViewModel);
                await _eventService.Adicionar(evento);
                return RedirectToAction(nameof(Index));
            }
            return View(eventViewModel);
        }

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


                return RedirectToAction(nameof(Index));
            }
            return View(eventViewModel);
        }

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var eventoExiste = await EventExistsAsync(id);
            if (eventoExiste)
            {
                await _eventService.Remover(id);
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