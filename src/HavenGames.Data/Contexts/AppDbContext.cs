using HavenGames.Business.Models;
using HavenGames.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;


namespace HavenGames.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions options): base (options) { }

        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.Inclusao = now;
                    entry.Entity.Alteracao = now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.Alteracao = now;
                }
            }
        }

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
