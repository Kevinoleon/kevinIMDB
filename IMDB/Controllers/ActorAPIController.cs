﻿using System;
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
        public IHttpActionResult Get()
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
                return Ok("no se pudo crear");
            }
            Actor actor = new Actor();
            ActorDtoMapper.MapFromDTOModel(actorDto, actor, session);

            
            session.Transaction.Commit();

            return Ok("se creó el Actor");
        }

        // PUT: api/ActorDTO/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Actor))]
        public async Task<IHttpActionResult> DeleteActor(int id)
        {
            Actor actorToDelete = session.Get<Actor>(id);
            if (actorToDelete == null)
            {
                return NotFound();
            }

            var ActorToDelete = session.Get<Actor>(id);
            session.Delete(ActorToDelete);
            session.Transaction.Commit();

            return Ok("se eliminò el Actor");
        }
    }
}
