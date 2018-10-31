using IMDB.Models;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class MovieController : Controller
    {
        private const int PageSize = 5;

        // GET: Movie
        public ActionResult Index(string query, int? pageIndex)
        {
            var pageInfo = new MoviePageInfo
            {
                PageItems = MovieStorage.GetByName(query, pageIndex ?? 0, PageSize),
                PageIndex = pageIndex ?? 0,
                PageCount = MovieStorage.GetCount() / PageSize + 1,
                SearchCriteria = query
            };

            return View("edit", pageInfo);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
