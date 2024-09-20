namespace HavenGames.App.ViewModels
{
    public class EventViewModel
    {
        public Guid Id { get; set; }
        public string  Imagem { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Localization{ get; set; }
        public DateTime Date { get; set; }
    }
}
