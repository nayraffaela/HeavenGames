namespace HavenGames.App.ViewModels
{
    public class JogoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Plataforma { get; set; }
        public string Genero { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public IList<PersonagemViewModel> Personagens { get; set; }
    }
}
