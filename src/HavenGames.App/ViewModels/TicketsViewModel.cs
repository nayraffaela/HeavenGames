using System.ComponentModel.DataAnnotations;

namespace HavenGames.App.ViewModels
{
    public class TicketsViewModel
    {
        [Key]
        public int Id { get; set; }
      
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Desconto { get; set; }
    }

}
