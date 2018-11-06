using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class MovieController : Controller
    {
        //private const int PageSize = 5;

        // GET: Movie
        public ActionResult Index(string searchString)
        {
            //string searchString = id;
            ISet<Movie> movies= new HashSet<Movie>();
            
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = MovieStorage.GetByName(searchString);
            }
            else
            {
                movies = MovieStorage.GetAll();
            }
            return View(movies);
        


            //---------------version sergio-----------------    
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

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            var Movie = MovieStorage.GetById(id);
            return View(Movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Movie newMovie)
        {
            
            MovieStorage.Save(newMovie);            
            return RedirectToAction("Index");
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            var MovietoEdit = MovieStorage.GetById(id);
            return View(MovietoEdit);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie movieToEdit)
        {

            MovieStorage.Save(movieToEdit);

            return RedirectToAction("Index");
            
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            var MovietoEdit = MovieStorage.GetById(id);
            return View(MovietoEdit);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(Movie movieToDelete)
        {
            MovieStorage.Delete(movieToDelete.Id);
            return RedirectToAction("Index");
        }
    }
}
