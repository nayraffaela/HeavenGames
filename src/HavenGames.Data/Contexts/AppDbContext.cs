using HavenGames.Business.Models;
using Microsoft.EntityFrameworkCore;


namespace HavenGames.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions options): base (options) { }

        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Personagem> Personagens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var propety in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p. ClrType == typeof(string))))
            {
                propety.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            
            foreach(var relatioship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relatioship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
