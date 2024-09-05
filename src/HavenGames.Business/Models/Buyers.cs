using HavenGames.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
