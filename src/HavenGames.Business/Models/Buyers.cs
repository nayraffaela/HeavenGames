using HavenGames.Business.Enums;

namespace HavenGames.Business.Models
{
    public class Buyers
    {
        public string Nome {  get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public Studant Studant { get; set; }

    }
}
