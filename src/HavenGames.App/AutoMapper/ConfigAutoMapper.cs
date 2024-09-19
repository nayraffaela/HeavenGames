using AutoMapper;
using HavenGames.App.ViewModels;
using HavenGames.Business.Models;

namespace HavenGames.App.AutoMapper
{
    public class ConfigAutoMapper: Profile 

    {
        public ConfigAutoMapper()
        {
            CreateMap<Ticket, TicketViewModel>().ReverseMap();
            CreateMap<Event, EventViewModel>().ReverseMap();

        }
    }
}
