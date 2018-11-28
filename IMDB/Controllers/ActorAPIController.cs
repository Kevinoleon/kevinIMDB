using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NHibernate;
using IMDB.Models;
using IMDB.Mappers;

namespace IMDB.Controllers
{
    public class ActorAPIController : ApiController
    {
        private readonly ISession session;

        public ActorAPIController()
        {
            this.session = NHibernate.SessionFactory.Instance.OpenSession();
            this.session.Transaction.Begin();
        }

        // GET: api/ActorAPI/
        public IHttpActionResult GetActors()
        {
            var actorDtos = from a in session.Query<Actor>()
                         select new ActorDisplayDTO()
                         {
                             Id = a.Id,
                             Name=a.Name,
                             Nationality = a.Nationality,
                             DateOfBirth=a.DateOfBirth,                         
                             Roles= a.ActorRoles.Select(r=>r.Name+" en "+r.Movie.OriginalTitle).ToList()
                         };

            return Ok(actorDtos);
        }
        // GET: api/ActorAPI/12
        [ResponseType(typeof(ActorDTO))]
        public IHttpActionResult GetActor(int id)
        {
            Actor sessionActor = session.Get<Actor>(id);
            if (sessionActor == null)
            {
                return Ok("Actor Doesn't exist");
            }
            var actorDto = new ActorDTO();

            ActorDtoMapper.MapToDTOModel(sessionActor, actorDto);
            

            return Ok(actorDto);
        }


        // POST: api/ActorDTO
        [ResponseType(typeof(Actor))]
        public IHttpActionResult PostActor(ActorDTO actorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Couldn't create");
            }

            if (session.Get<Actor>(actorDto.Id) != null)
            {
                return BadRequest("Actor already exists");
            }

            Actor actor = new Actor();
            ActorDtoMapper.MapFromDTOModel(actorDto, actor, session);

            session.Transaction.Commit();

            return Ok("Actor created");
        }

        // PUT: api/ActorDTO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActor(ActorDTO actorDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Couldn't edit");
            }

            Actor sessionActor = session.Get<Actor>(id);

            if (sessionActor == null)
            {
                return Ok("Actor Doesn't exist");
            }

            //sessionActor.ActorRoles.Clear()

            ActorDtoMapper.MapFromDTOModel(actorDto, sessionActor, session);

            session.Transaction.Commit();
            

            return Ok("Actor edited");         



            

        }

        // DELETE: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteActor(int id)
        {
            Actor actorToDelete = session.Get<Actor>(id);
            if (actorToDelete == null)
            {
                return Ok("Actor doesn't exist");
            }

            var ActorToDelete = session.Get<Actor>(id);
            session.Delete(ActorToDelete);
            session.Transaction.Commit();

            return Ok("Actor deleted");
        }
    }
}
