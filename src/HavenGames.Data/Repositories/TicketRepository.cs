using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HavenGames.Data.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<Ticket> ObterTicket(Guid id)
        {
            return await Db.Tickets.AsNoTracking().Include(t => t.Event).FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
