
using HavenGames.Business.Models;

namespace HavenGames.Business.Services
{
    public interface IJogoService : IDisposable
    {
        Task Adicionar(Jogo jogo);

        Task Alterar (Jogo jog);

        Task Remover (Jogo jog);

        }
}
