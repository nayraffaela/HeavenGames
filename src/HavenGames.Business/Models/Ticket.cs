using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavenGames.Business.Models
{
    public class Ticket: BaseEntity
    {
        public int EventId { get; set; }
        public decimal Value { get; set; }
        public Event Event { get; set; }
        public string BuyerName { get; set; }
        public string BuyerCPF { get; set; }
        public string TicketType { get; set; } // e.g., "Desconto", "Normal"
        public string PaymentMethod { get; set; }

    }
}
