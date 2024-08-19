using System.ComponentModel.DataAnnotations;

namespace HavenGames.Business.Models
{
    public class Jogo : BaseEntity
    {
      
        public string Nome { get; set; }
        public string Plataforma { get; set; }
        public string Genero { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public IList<Personagem> Personagens { get; set; }
    }
}
