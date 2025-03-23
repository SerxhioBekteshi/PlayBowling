using AutoMapper;
using Entities.Models;
using Shared.DTO;

namespace ProjectBackEnd;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Player, PlayerDTO>().ReverseMap();
        CreateMap<Game, GameDTO>().ReverseMap();

    }
}