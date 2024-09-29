using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;

namespace HavenGames.Business.Services
{
    public class CommentService : BaseService, ICommentService
    {
        private readonly ICommentService _commentService;

        public CommentService(INotificador notificador) : base(notificador)
        {

        }

        public Task Adicionar(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }


}
