using ActorsManagerService.Data;
using ActorsManagerService.Dtos;
using ActorsManagerService.Handlers;
using ActorsManagerService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace ActorsManagerService.Services
{
    public class ActorsService : IActorsService
    {
        private readonly IActorsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IErrorHandler _errorHandler;

        public ActorsService(IActorsRepository repository, IMapper mapper, IErrorHandler errorHandler)
        {
            _repository = repository;
            _mapper = mapper;
            _errorHandler = errorHandler;
        }

        public ContentResult CreateActor(ActorCreateRequestDto actorCreateDto)
        {
            try
            {
                var actor = _mapper.Map<Actor>(actorCreateDto);

                _repository.CreateActor(actor);

                _repository.SaveChanges();

                var actorCreatedDto = _mapper.Map<ActorCreateResponseDto>(actor);

                return CreateResponse(HttpStatusCode.OK, JsonSerializer.Serialize(actorCreatedDto));
            }
            catch (Exception ex)
            {
                return CreateResponse(_errorHandler.GetHttpStatusCode(ex), ex.Message);
            }
        }

        public ContentResult DeleteActor(ActorDeleteRequestDto actorDeleteRequestDto)
        {
            try
            {
                var actor = _mapper.Map<Actor>(actorDeleteRequestDto);

                _repository.DeleteActor(actor);

                _repository.SaveChanges();

                var actorCreatedDto = _mapper.Map<ActorDeleteResponseDto>(actor);

                return CreateResponse(HttpStatusCode.OK, $"Actor with id {actor.Id} successfully deleted");
            }
            catch (Exception ex)
            {
                return CreateResponse(_errorHandler.GetHttpStatusCode(ex), ex.Message);
            }
        }

        public ContentResult GetActorById(int id)
        {
            try
            {
                var actor = _repository.GetActorById(id);

                if (actor != null)
                {
                    var actorGetByIdResponseDto = _mapper.Map<ActorGetByIdResponseDto>(actor);

                    return CreateResponse(HttpStatusCode.OK, JsonSerializer.Serialize(actorGetByIdResponseDto));
                }

                return CreateResponse(_errorHandler.GetHttpStatusCode(new ArgumentException()), "Actor Not Found");

            }
            catch (Exception ex)
            {
                return CreateResponse(_errorHandler.GetHttpStatusCode(ex), ex.Message);             
            }
        }

        public ContentResult GetAllActors(ActorGetRequestDto actorGetRequestDto)
        {
            try
            {
                var actors = _repository.GetAllActors(actorGetRequestDto);

                var actorGetResponseDto = _mapper.Map<IEnumerable<ActorGetResponseDto>>(actors).ToList();

                return CreateResponse(HttpStatusCode.OK, JsonSerializer.Serialize(actorGetResponseDto));   
            }
            catch (Exception ex)
            {
                return CreateResponse(_errorHandler.GetHttpStatusCode(ex), ex.Message);
            }
        }

        public ContentResult UpdateActor(ActorUpdateRequestDto actorUpdateRequestDto)
        {
            try
            {
                var actor = _mapper.Map<Actor>(actorUpdateRequestDto);

                _repository.UpdateActor(actor);

                _repository.SaveChanges();

                var actorCreatedDto = _mapper.Map<ActorUpdateResponseDto>(actor);

                return CreateResponse(HttpStatusCode.OK, JsonSerializer.Serialize(actorCreatedDto));
            }
            catch (Exception ex)
            {
                return CreateResponse(_errorHandler.GetHttpStatusCode(ex), ex.Message);

            }
        }

        private static ContentResult CreateResponse(HttpStatusCode httpStatusCode, string content)
        {
            return new ContentResult()
            {
                StatusCode = (int )httpStatusCode,
                Content = content
            };
        }
    }
}
