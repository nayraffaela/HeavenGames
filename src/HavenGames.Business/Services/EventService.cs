using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Business.Validation;

namespace HavenGames.Business.Services
{
    public class EventService : BaseService, IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventrepository, INotificador notificador) : base(notificador)
        {
            _eventRepository = eventrepository;
        }

        public async Task Adicionar(Event evento)
        {
            if (!ExecutarValidacao(new EventValidation(), evento)) return;

            if (_eventRepository.Buscar(c => c.Name == evento.Name).Result.Any())
            {
                Notificar("Já existe um evento cadastrado com o nome informado.");
                return;
            }

            await _eventRepository.Adicionar(evento);
        }

        public async Task Alterar(Event evento)
        {
            if (!ExecutarValidacao(new EventValidation(), evento)) return;
            await _eventRepository.Alterar(evento);
        }

        public void Dispose()
        {
            _eventRepository.Dispose();
        }

        public async Task Remover(Guid id)
        {
            await _eventRepository.Remover(id);
        }
    }
}
