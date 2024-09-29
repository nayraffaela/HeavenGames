using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HavenGames.Data.Repositories
{

    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepository(AppDbContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }
        public async Task Adicionar(TEntity entity)
        {
            Db.Add(entity);
            await SaveChanges();
        }

        public async Task Alterar(TEntity entity)
        {
            Db.Update(entity);
            await SaveChanges();
        }

        public async Task Remover(Guid id)
        {
            Db.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}