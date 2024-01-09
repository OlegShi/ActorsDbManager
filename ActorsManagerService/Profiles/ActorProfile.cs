using ActorsManagerService.Dtos;
using ActorsManagerService.Models;
using AutoMapper;

namespace ActorsManagerService.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorGetResponseDto>();
            CreateMap<Actor, ActorGetByIdResponseDto>();
            CreateMap<ActorCreateRequestDto, Actor>();
            CreateMap<Actor, ActorCreateResponseDto>();
            CreateMap<ActorUpdateRequestDto, Actor>();
            CreateMap<Actor, ActorUpdateResponseDto>();
            CreateMap<ActorDeleteRequestDto, Actor>();
            CreateMap<Actor, ActorDeleteResponseDto>();
        }
    }
}
