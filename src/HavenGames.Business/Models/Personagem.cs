

namespace HavenGames.Business.Models
{
    public class Personagem : BaseEntity
    {
        public Guid JogoId { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public Jogo Jogo { get; set; }
    }
}

