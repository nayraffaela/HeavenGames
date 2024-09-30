using AutoMapper;
using HavenGames.App.ViewModels;
using HavenGames.Business.Models;

namespace HavenGames.App.AutoMapper
{
    public class ConfigAutoMapper : Profile

    {
        public ConfigAutoMapper()
        {
            CreateMap<Event, EventViewModel>().ReverseMap();
            CreateMap<Comment, CommentFormViewModel>().ReverseMap();
            CreateMap<Curriculum, CurriculumViewModel>().ReverseMap();
            CreateMap<Personagem, PersonagemViewModel>().ReverseMap();

        }
    }
}
