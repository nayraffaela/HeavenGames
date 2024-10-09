using HavenGames.Business.Models;

namespace HavenGames.Business.Services
{
    public interface ICommentService : IDisposable
    {
        Task Adicionar(Comment comment);
        Task<IEnumerable<Comment>> ObterTodos();
    }
}
