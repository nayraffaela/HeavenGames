using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HavenGames.App.ViewModels
{
    public class JogoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatória")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A plataforma é obrigatória")]
        [DisplayName("Plataforma")]
        public string Plataforma { get; set; }

        [Required(ErrorMessage = "O gênero é obrigatória")]
        [DisplayName("Gênero")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "A imagem é obrigatória")]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [DisplayName("Descriçao")]
        public string Descricao { get; set; }
        public List<PersonagemViewModel> Personagens { get; set; }
    }
}
