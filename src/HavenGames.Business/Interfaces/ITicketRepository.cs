using HavenGames.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavenGames.Business.Interfaces
{
    public interface ITicketRepository : IBaseRepository <Ticket>
    {
        Task<Ticket> ObterTicket (Guid id);
    }
}
