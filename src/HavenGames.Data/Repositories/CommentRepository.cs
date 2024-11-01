using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HavenGames.Data.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext db) : base(db)
        {
            
        }

        public async Task<IEnumerable<Comment>> ObterTodosOrdenadosPorData()
        {
            return await DbSet
                           .OrderByDescending(c => c.Inclusao)
                           .ToListAsync();
        }
    }
}

