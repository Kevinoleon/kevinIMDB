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
    public class MovieAPIController : ApiController
    {
        private readonly ISession session;

        public MovieAPIController()
        {
            
            this.session = NHibernate.SessionFactory.Instance.OpenSession();
            this.session.Transaction.Begin();
        }

        // GET: api/MovieAPI/
        public IHttpActionResult GetMovies()
        {
            var movies = session.Query<Movie>();
            if (movies != null)
            {
                var movieDtos = from a in movies
                                select new MovieDisplayDTO()
                                {
                                    Id = a.Id,
                                    OriginalTitle = a.OriginalTitle,
                                    Country = a.Country,
                                    ReleaseDate = a.ReleaseDate,
                                    Characters = a.MovieRoles.Select(r => r.Name + " Played by " + r.Actor.Name).ToList()
                                };

                return Ok(movieDtos);                
            }
            else
            {
                return NotFound();
            }
            
        }
        // GET: api/MovieAPI/12
        [ResponseType(typeof(MovieDTO))]
        public IHttpActionResult GetMovie(int id)
        {
            Movie sessionMovie = session.Get<Movie>(id);
            if (sessionMovie == null)
            {
                return BadRequest("Movie Doesn't exist");
            }
            var movieDto = new MovieDTO();

            MovieDtoMapper.MapToDTOModel(sessionMovie, movieDto);
            

            return Ok(movieDto);
        }


        // POST: api/MovieDTO
        [ResponseType(typeof(Movie))]
        public IHttpActionResult PostMovie(MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Couldn't create");
            }

            if (session.Get<Movie>(movieDto.Id) != null)
            {
                return BadRequest("Movie already exists");
            }

            Movie movie = new Movie();
            MovieDtoMapper.MapFromDTOModel(movieDto, movie, session);

            session.Transaction.Commit();

            return Ok("Movie created");
        }

        // PUT: api/MovieDTO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(MovieDTO movieDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Couldn't edit");
            }

            Movie sessionMovie = session.Get<Movie>(id);

            if (sessionMovie == null)
            {
                return BadRequest("Movie Doesn't exist");
            }

            //sessionMovie.MovieRoles.Clear()

            MovieDtoMapper.MapFromDTOModel(movieDto, sessionMovie, session);

            session.Transaction.Commit();
            

            return Ok("Movie edited");         



            

        }

        // DELETE: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movieToDelete = session.Get<Movie>(id);
            if (movieToDelete == null)
            {
                return BadRequest("Movie doesn't exist");
            }

            var MovieToDelete = session.Get<Movie>(id);
            session.Delete(MovieToDelete);
            session.Transaction.Commit();

            return Ok("Movie deleted");
        }
    }
}
