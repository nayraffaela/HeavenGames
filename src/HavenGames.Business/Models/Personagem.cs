

namespace HavenGames.Business.Models
{
    public class Personagem: Jogo
    {
        public string NomePersonagem{ get; set; }
        public string ImagemPersonagem { get; set; }
        public string DescricaoPersonagem { get; set; }
        public Jogo Jogo { get; set; }
    }
}

