using ActorsManagerService.Dtos;
using ActorsManagerService.Models;

namespace ActorsManagerService.Data
{
    public interface IActorsRepository
    {
        bool SaveChanges();
        IEnumerable<Actor>? GetAllActors(ActorGetRequestDto actorGetRequestDto);
        Actor? GetActorById(int id);
        void CreateActor(Actor actor);
        void UpdateActor(Actor actor);
        void DeleteActor(Actor actor);
    }
}
