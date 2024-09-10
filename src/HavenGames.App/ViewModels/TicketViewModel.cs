using HavenGames.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HavenGames.App.ViewModels
{
    public class TicketViewModel
    {
        [Key]
        
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Este campo é obrigatório")]

        public Guid EventId { get; set; }
        public EventViewModel Event { get; set; }
        public IEnumerable<EventViewModel> Events { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do fornecedor deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [DisplayName("Nome Completo")]
        public string BuyerName { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(11, ErrorMessage = "O documento do fornecedor deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [DisplayName("CPF do comprador")]
        public string BuyerCPF { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Valor")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Tipo de Ingresso")]
        public int TicketType { get; set; }

        [Required(ErrorMessage = "Este opção é obrigatório")]
        [DisplayName("Método de pagamento")]
        public string PaymentMethod { get; set; }
    }


}
