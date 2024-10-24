using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HavenGames.App.ViewModels
{

    public class EventViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A imagem é obrigatória")]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A localização é obrigatória")]
        [DisplayName("Localização")]
        public string Localization { get; set; }

        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime Date { get; set; }
    }
}
