
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HavenGames.App.ViewModels
{
    public class PersonagemViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A imagem é obrigatória")]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [DisplayName("Nome")]
        public string Descricao { get; set; }
        public JogoViewModel Jogo { get; set; }
    }
}
