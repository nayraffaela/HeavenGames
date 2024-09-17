using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HavenGames.App.ViewModels;

namespace HavenGames.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public object Events { get; internal set; }
        public DbSet<HavenGames.App.ViewModels.TicketViewModel> TicketViewModel { get; set; } = default!;
        public DbSet<HavenGames.App.ViewModels.EventViewModel> EventViewModel { get; set; } = default!;
    }
}
