using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavenGames.Business.Models
{
    public class CommentForm:BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
