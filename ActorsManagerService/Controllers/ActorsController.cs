using ActorsManagerService.Dtos;
using ActorsManagerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ActorsManagerService.Controllers
{
    [ApiController]
    [Route("api/v1/actors")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService actorsService)
        {
            _actorsService = actorsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ActorGetResponseDto>> GetAllActors([FromQuery] ActorGetRequestDto actorGetRequestDto)
        {
            return _actorsService.GetAllActors(actorGetRequestDto);
        }

        [HttpGet("{id}")]
        public ActionResult<ActorGetByIdResponseDto> GetActorById(int id)
        {
            return _actorsService.GetActorById(id);
        }


        [HttpPost]
        public ActionResult<ActorCreateResponseDto> CreateActor(ActorCreateRequestDto actorCreateDto)
        {
            return _actorsService.CreateActor(actorCreateDto);
        }

        [HttpPut]
        public ActionResult<ActorUpdateResponseDto> UpdateActor(ActorUpdateRequestDto actorUpdateRequestDto)
        {
            return _actorsService.UpdateActor(actorUpdateRequestDto);
        }

        [HttpDelete]
        public ActionResult<ActorDeleteResponseDto> DeleteActor(ActorDeleteRequestDto actorDeleteRequestDto)
        {
            return _actorsService.DeleteActor(actorDeleteRequestDto);
        }

    }
}
