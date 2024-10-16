using HavenGames.Business.Models;

namespace HavenGames.Business.Interfaces
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task<IEnumerable<Comment>> ObterTodos();
    }
}

