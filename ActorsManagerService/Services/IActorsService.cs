using ActorsManagerService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ActorsManagerService.Services
{
    public interface IActorsService
    {
        ContentResult GetAllActors(ActorGetRequestDto actorGetRequestDto);
        ContentResult GetActorById(int id);
        ContentResult CreateActor(ActorCreateRequestDto actorCreateDto);
        ContentResult UpdateActor(ActorUpdateRequestDto actorUpdateRequestDto);
        ContentResult DeleteActor(ActorDeleteRequestDto actorUpdateRequestDto);
        
    }
}
