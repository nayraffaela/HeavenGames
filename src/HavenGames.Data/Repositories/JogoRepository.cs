using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Data.Contexts;

namespace HavenGames.Data.Repositories
{
    public class JogoRepository : BaseRepository<Jogo>, IJogoRepository
    {
        public JogoRepository(AppDbContext db) : base(db)
        {
        }



    }
}

