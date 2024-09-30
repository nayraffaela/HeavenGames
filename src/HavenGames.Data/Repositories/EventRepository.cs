using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Data.Contexts;

namespace HavenGames.Data.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(AppDbContext db) : base(db)
        {

        }

        
    }
}

