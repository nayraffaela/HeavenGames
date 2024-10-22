using HavenGames.App.AutoMapper;
using HavenGames.Business.Interfaces;
using HavenGames.Business.Notification;
using HavenGames.Business.Services;
using HavenGames.Data.Repositories;

namespace HavenGames.App.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services )
        {
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IJogoRepository, JogoRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IJogoService, JogoService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
           
    }
}
