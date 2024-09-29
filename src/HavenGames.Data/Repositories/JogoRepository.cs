using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HavenGames.Data.Repositories
{
    public class JogoRepository : BaseRepository<Jogo>, IJogoRepository
    {
        public JogoRepository(AppDbContext db) : base(db)
        {
        }

        public async Task AdicionarPersonagem(Personagem personagem)
        {
            await Db.AddAsync(personagem);
        }

        public async Task AlterarPersonagem(Personagem personagem)
        {
            Db.Update(personagem);
            await Db.SaveChangesAsync();
        }

        public async Task<Jogo> ObterJogoComPersonagens(Guid jogoId)
        {
            var jogo = await Db.Jogos.Include(t => t.Personagens)
                  .FirstOrDefaultAsync(m => m.Id == jogoId);

            return jogo;
        }
    }
}

