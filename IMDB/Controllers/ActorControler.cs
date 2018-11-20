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
            ViewBag.Movies = session.Query<Movie>();
            return View(ActortoEdit);
        }

        // POST: Actor/Edit/5
        [HttpPost]
        public ActionResult Edit(Actor actorToEdit)
        {
            var actor = session.Get<Actor>(actorToEdit.Id);
            actor.Name = actorToEdit.Name;
            actor.Nationality = actorToEdit.Nationality;
            actor.DateOfBirth = actorToEdit.DateOfBirth;            

            var roleIds = this.Request.Form.GetValues("MovieRoleId");
            var titles = this.Request.Form.GetValues("MovieRoleTitle");
            var movieIds = this.Request.Form.GetValues("MovieRoleMovie");

            actor.ActorRoles.Clear();       //------no me gusta pero no sè como màs hacerlo

            if (titles != null || movieIds!=null)
            {                
                for (int index = 0; index < titles.Length; ++index)
                {                    
                    var roleId = int.Parse(roleIds[index]);

                    Role role;
                    if (roleId == 0)
                    {
                        // crear nuevo rol
                        role = new Role
                        {                            
                            Actor = actor,
                            Name = titles[index],
                            Movie = session.Get<Movie>(int.Parse(movieIds[index]))
                        };
                    }
                    else {
                        // actualizar el existente
                        role = session.Get<Role>(roleId);
                        if (role != null)
                        {                            
                            role.Actor = actor;
                            role.Name = titles[index];
                            role.Movie = session.Get<Movie>(int.Parse(movieIds[index]));
                        }
                        else
                        {
                            // error
                        }
                    }
                    actor.ActorRoles.Add(role);
                }
            }

            else
            {
                actor.ActorRoles.Clear();
            }

            session.Update(actor);
            session.Transaction.Commit();

            ViewBag.Movies = session.Query<Movie>();

            return RedirectToAction("Index");
            //return RedirectToAction("Edit", new { id = actorToEdit.Id });
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
