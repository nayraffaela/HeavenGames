using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HavenGames.Data.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<Event> ObterEvent(Guid id)
        {
            return await Db.Events.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}

