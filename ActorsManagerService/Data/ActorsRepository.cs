using ActorsManagerService.Dtos;
using ActorsManagerService.Models;

namespace ActorsManagerService.Data
{
    public class ActorsRepository : IActorsRepository
    {
        private readonly AppDbContext _context;

        public ActorsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateActor(Actor actor)
        {
            if(actor == null)
            {
                throw new ArgumentNullException(nameof(actor));
            }

            _context?.Actors?.Add(actor);
        }

        public Actor? GetActorById(int id)
        {
            return _context?.Actors?.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Actor>? GetAllActors(ActorGetRequestDto actorGetRequestDto)
        {
            if (!string.IsNullOrEmpty(actorGetRequestDto.ActorName))
                return _context?.Actors?.Where(a => a.Name == actorGetRequestDto.ActorName);
            
            var rankFiltered = _context?.Actors?.Where(a => a.Rank >= actorGetRequestDto.MinRank && a.Rank <= actorGetRequestDto.MaxRank);
            
            return rankFiltered?.Skip((actorGetRequestDto.PageNumber-1) * actorGetRequestDto.PageSize).Take(actorGetRequestDto.PageSize).ToList();
        }

        public void UpdateActor(Actor actor)
        {
            if (actor == null)
            {
                throw new ArgumentNullException(nameof(actor));
            }

            var existingActor = _context?.Actors?.FirstOrDefault(a => a.Id == actor.Id);

            if (existingActor != null)
            {             
                var actorWithSameRank = _context?.Actors?.FirstOrDefault(a => a.Id != actor.Id && a.Rank == actor.Rank);

                if (actorWithSameRank != null)
                {
                    throw new InvalidOperationException("Another actor with the same rank already exists.");
                }

                existingActor.Name = actor.Name;
                existingActor.Details = actor.Details;
                existingActor.Rank = actor.Rank;
            }
            else
            {
                throw new ArgumentException("Actor not found", nameof(actor));
            }
        }
        public void DeleteActor(Actor actor)
        {
            var actorToDelete = _context?.Actors?.FirstOrDefault(a => a.Id == actor.Id);

            if (actorToDelete != null)
            {
                _context?.Actors?.Remove(actorToDelete);
            }
            else
            {
                throw new ArgumentException("Actor not found", nameof(actor.Id));
            }
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }


    }
}
