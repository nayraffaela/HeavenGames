using HavenGames.Business.Models;
using System.Linq.Expressions;

namespace HavenGames.Business.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task Adicionar(TEntity entity);
        Task Alterar(TEntity entity);
        Task Remover(Guid id);
        Task<TEntity> ObterPorId(Guid id);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
