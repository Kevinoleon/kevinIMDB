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
            //string searchString = id;
            //IList<Movie> movies= new List<Movie>();

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    //Where(m => m.OriginalTitle.ToLower().Contains(searchString.ToLower()))
            //    movies = this.session.Query<Movie>()
            //        .Where(m => m.OriginalTitle.ToLower().Contains(searchString.ToLower()))
            //        .ToList();
            //}
            //else
            //{
            //    movies = this.session.Query<Movie>().ToList();
            //}
            //return View(movies);

            //---------------ver optimizada----------------------------
            var movies = String.IsNullOrEmpty(searchString)
           ? this.session.Query<Movie>().ToList() : this.session.Query<Movie>()
                   .Where(m => m.OriginalTitle.ToLower().Contains(searchString.ToLower()))
                   .ToList();
            return View(movies);
            //---------------------------------------------------------


            //---------------paginaciòn sergio-----------------    
            //var pageInfo = new MoviePageInfo
            //{
            //    PageItems = MovieStorage.GetByName(query, pageIndex ?? 0, PageSize),
            //    PageIndex = pageIndex ?? 0,
            //    PageCount = MovieStorage.GetCount() / PageSize + 1,
            //    SearchCriteria = query
            //};

            //return View("edit", pageInfo);
            //-------------------------------------------------

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
            return View(MovieToEdit);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie movieToEdit)
        {

            session.Update(movieToEdit);
            this.session.Transaction.Commit();

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
