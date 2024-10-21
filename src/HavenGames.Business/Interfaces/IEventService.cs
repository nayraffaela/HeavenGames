
using HavenGames.Business.Models;

namespace HavenGames.Business.Services
{
    public interface IEventService : IDisposable
    {
        Task Adicionar(Event evento);

        Task Alterar(Event evento);

        Task Remover(Guid id);

    }
}
