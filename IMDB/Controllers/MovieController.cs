using IMDB.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class MovieController : Controller
    {
        private readonly ISession session;
        public MovieController()
        {
            this.session = NHibernate.SessionFactory.Instance.OpenSession();
            this.session.Transaction.Begin();
        }


        // GET: Movie
        [ActionName("Index")]
        public ActionResult Index(string searchString)
        {
            
            var movies = String.IsNullOrEmpty(searchString)
           ? this.session.Query<Movie>().ToList() : this.session.Query<Movie>()
                   .Where(m => m.OriginalTitle.ToLower().Contains(searchString.ToLower()))
                   .ToList();
            return View(movies);
            

        }

        // GET: Movie/Details/5___________________________________________________________
        public ActionResult Details(int id)
        {
            var Movie = this.session.Get<Movie>(id);
            return View(Movie);
        }

        // GET: Movie/Create___________________________________________________________________________________________
        public ActionResult Create()
        {
            var NewMovie = new Movie();
            return View(NewMovie);
        }

        // POST: Movie/Create
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie newMovie)
        {

            session.Save(newMovie);
            this.session.Transaction.Commit();
            return RedirectToAction("Index");
        }

        // GET: Movie/Edit/5_____________________________________________________________________________________________
        public ActionResult Edit(int id)
        {
            var MovieToEdit = this.session.Get<Movie>(id);
            ViewBag.Actors = session.Query<Actor>();
            return View(MovieToEdit);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie movieToEdit)
        {
            var Movie = session.Get<Movie>(movieToEdit.Id);
            Movie.OriginalTitle = movieToEdit.OriginalTitle;
            Movie.ReleaseDate = movieToEdit.ReleaseDate;
            Movie.Country = movieToEdit.Country;

            var roleIds = this.Request.Form.GetValues("RoleId");
            var names = this.Request.Form.GetValues("RoleName");
            var actorIds = this.Request.Form.GetValues("RoleActor");

            Movie.MovieRoles.Clear();

            if (names != null || actorIds != null)
            {
                for (int index = 0; index < names.Length; ++index)
                {
                    var roleId = int.Parse(roleIds[index]);
                    Role role;
                    if (roleId == 0) //compruebo si es un nuevo role
                    {
                        //creo un nuevo role
                        role = new Role
                        {
                            Movie = Movie,
                            Name = names[index],
                            Actor = session.Get<Actor>(int.Parse(actorIds[index]))
                        };
                    }
                    else
                    {
                        //actualizo el role existente
                        role = session.Get<Role>(roleId);
                        role.Movie = Movie;
                        role.Name = names[index];
                        role.Actor = session.Get<Actor>(int.Parse(actorIds[index]));
                    }
                    Movie.MovieRoles.Add(role);
                }

                session.Update(Movie);
                this.session.Transaction.Commit();

                return RedirectToAction("Index");

            }
            else
            {
                Movie.MovieRoles.Clear();
            }

            session.Update(Movie);
            session.Transaction.Commit();

            ViewBag.Actors = session.Query<Actor>();

            return RedirectToAction("Index");
        }

        // GET: Movie/Delete/5______________________________________________________________________________________________
        public ActionResult Delete(int id)
        {
            Movie MovieToDelete = this.session.Get<Movie>(id);
            return View(MovieToDelete);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            Movie MovieToDelete = this.session.Get<Movie>(id);
            this.session.Delete(MovieToDelete);
            this.session.Transaction.Commit();

            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.session.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
