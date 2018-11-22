using NHibernate;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Threading.Tasks;

namespace IMDB.Controllers
{
    public class ActorDTOController : ApiController
    {
        private readonly ISession session;

        public ActorDTOController()
        {
            this.session = NHibernate.SessionFactory.Instance.OpenSession();
            this.session.Transaction.Begin();
        }

        // GET: api/ActorDTO
        public IHttpActionResult Get()
        {
            var actorDtos = from a in session.Query<Actor>()
                         select new ActorDTO()
                         {
                             Id = a.Id,
                             Name=a.Name,
                             Nationality = a.Nationality,
                             DateOfBirth=a.DateOfBirth,                         
                             Roles= a.ActorRoles.Select(r=>r.Name+"-"+r.Movie.OriginalTitle).ToList()
                         };

            return Ok(actorDtos);
        }

        [ResponseType(typeof(ActorDTO))]
        public async Task<IHttpActionResult> GetActor(int id)
        {
            var actor=session.Query<Actor>().Select(a =>
                new ActorDTO()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Nationality = a.Nationality,
                    Roles = a.ActorRoles.Select(r => r.Name + " in " + r.Movie.OriginalTitle).ToList()
                }).SingleOrDefault(a => a.Id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }

        //// POST: api/ActorDTO
        //[ResponseType(typeof(Actor))]
        //public async Task<IHttpActionResult> PostActor(ActorDTO actor)
        //{
        //    List<Role> roles = await db.Authors.SingleOrDefaultAsync(a => a.Name == bookDetailDto.AuthorName);

        //    var book = new Book
        //    {
        //        AuthorId = author.Id,
        //        Genre = bookDetailDto.Genre,
        //        Price = bookDetailDto.Price,
        //        Title = bookDetailDto.Title,
        //        Year = bookDetailDto.Year
        //    };

        //    db.Books.Add(book);
        //    await db.SaveChangesAsync();

        //    var dto = new BookDTO()
        //    {
        //        Id = bookDetailDto.Id,
        //        Title = bookDetailDto.Title,
        //        AuthorName = bookDetailDto.AuthorName
        //    };

        //    return CreatedAtRoute("DefaultApi", new { id = dto.Id }, dto);
        //}

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
