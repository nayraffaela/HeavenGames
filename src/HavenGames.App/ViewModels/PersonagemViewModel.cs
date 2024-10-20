namespace HavenGames.App.ViewModels
{
    public class PersonagemViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public JogoViewModel Jogo { get; set; }
    }
}
