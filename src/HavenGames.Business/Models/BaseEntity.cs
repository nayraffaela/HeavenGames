namespace HavenGames.Business.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Inclusao { get; set; }
        public DateTime Alteracao { get; set; }
    }
}
