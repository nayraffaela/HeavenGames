using HavenGames.Business.Models;

namespace HavenGames.App.ViewModels
{
    public class CommentFormViewModel
    {
        public class CommentForm : BaseEntity
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
        }
    }
}
