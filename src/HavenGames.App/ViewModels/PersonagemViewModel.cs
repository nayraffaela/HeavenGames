using HavenGames.Business.Models;

namespace HavenGames.App.ViewModels
{
    public class PersonagemViewModel
    {
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public Jogo Jogo { get; set; }
    }
}
