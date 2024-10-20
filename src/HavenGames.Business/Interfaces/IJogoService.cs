
using HavenGames.Business.Models;

namespace HavenGames.Business.Services
{
    public interface IJogoService : IDisposable
    {
        Task Adicionar(Jogo jogo);
        Task Alterar(Jogo jogo);
        Task Remover(Guid id);
        Task AdicionarPersonagem(Jogo jogo, Personagem personagem);
        Task AlterarPersonagem(Personagem existingPersonagem);
        Task RemoverPersonagem(Jogo jogo, Personagem personagem);
    }
}
