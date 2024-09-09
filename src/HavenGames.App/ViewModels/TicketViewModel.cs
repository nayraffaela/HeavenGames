using HavenGames.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace HavenGames.App.ViewModels
{
    public class TicketViewModel
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        public EventViewModel Event { get; set; }
        public IEnumerable<EventViewModel> Events { get; set; }
        public string BuyerName { get; set; }
        public string BuyerCPF { get; set; }
        public string TicketType { get; set; } 
        public string PaymentMethod { get; set; }
    }

}
