using IMDB.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace IMDB.Controllers
{
    public class ActorController : Controller
    {
        //private const int PageSize = 5;

        private readonly ISession session;
        public ActorController()
        {
            this.session = NHibernate.SessionFactory.Instance.OpenSession();
            this.session.Transaction.Begin();
        }

        // GET: Actor_________________________________________________________________
        [ActionName("Index")]
        public ActionResult Index(string searchString)
        {
            
            var Actors = String.IsNullOrEmpty(searchString)
          ? this.session.Query<Actor>().ToList() : this.session.Query<Actor>()
                  .Where(m => m.Name.ToLower().Contains(searchString.ToLower()))
                  .ToList();
            return View(Actors);
           

        }

        // GET: Actor/Details/5___________________________________________________
        public ActionResult Details(int id)
        {
            var Actor = session.Get<Actor>(id);
            return View(Actor);
        }

        // GET: Actor/Create______________________________________________________
        public ActionResult Create()
        {
            var NewActor = new Actor();
            return View(NewActor);
        }

        // POST: Actor/Create
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actor newActor)
        {
            session.Save(newActor);
            session.Transaction.Commit();
            return RedirectToAction("Index");
        }

        // GET: Actor/Edit/5_________________________________________________________
        public ActionResult Edit(int id)
        {
            var ActortoEdit = session.Get<Actor>(id);
            return View(ActortoEdit);
        }

        // POST: Actor/Edit/5
        [HttpPost]
        public ActionResult Edit(Actor actorToEdit)
        {

            session.Update(actorToEdit);
            session.Transaction.Commit();

            return RedirectToAction("Index");
            
        }

        // GET: Actor/Delete/5____________________________________________________________
        public ActionResult Delete(int id)
        {
            var ActortoDelete = session.Get<Actor>(id);
            return View(ActortoDelete);
        }

        // POST: Actor/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {

            var ActorToDelete = session.Get<Actor>(id);
            session.Delete(ActorToDelete);
            session.Transaction.Commit();

            return RedirectToAction("Index");
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
