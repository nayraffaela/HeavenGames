using HavenGames.Business.Models;

namespace HavenGames.Business.Interfaces
{
    public interface IJogoRepository : IBaseRepository<Jogo>
    {
        Task AdicionarPersonagem(Personagem personagem);
        Task AlterarPersonagem(Personagem personagem);
        Task<Jogo> ObterJogoComPersonagens(Guid jogoId);
        void Remover(Personagem item);
    }
}

