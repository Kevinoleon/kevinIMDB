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

            var actor = String.IsNullOrEmpty(searchString)
                ? this.session.Query<Actor>().ToList()
                : this.session.Query<Actor>()
                    .Where(m => m.Name.ToLower().Contains(searchString.ToLower()))
                    .ToList();
            return View(actor);


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

            // TODO: agregar logica de mapeo de roles

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
        public ActionResult Edit(Actor requestActor)
        {
            var roleIds = this.Request.Form.GetValues("MovieRoleId");
            var titles = this.Request.Form.GetValues("MovieRoleTitle");
            var movieIds = this.Request.Form.GetValues("MovieRoleMovie");

            if (titles != null && movieIds != null)
            {
                for (int index = 0; index < Math.Min(titles.Length, movieIds.Length); ++index)
                {
                    requestActor.ActorRoles.Add(new Role
                    {
                        Id = int.Parse(roleIds[index]),
                        Actor = requestActor,
                        Name = titles[index],
                        Movie = new Movie { Id = int.Parse(movieIds[index]) },
                    });
                }
            }

            // requestActor tiene todos los datos que llegaron del request

            var sessionActor = session.Get<Actor>(requestActor.Id);

            sessionActor.Name = requestActor.Name;
            sessionActor.Nationality = requestActor.Nationality;
            sessionActor.DateOfBirth = requestActor.DateOfBirth;

            /*sessionActor.ActorRoles.Clear();
            foreach (var requestRole in requestActor.ActorRoles) {
                var sessionRole = requestRole.Id == 0 ? new Role() : session.Get<Role>(requestRole.Id);
                sessionRole.Name = requestRole.Name;
                sessionRole.Actor = sessionActor;
                sessionRole.Movie = session.Get<Movie>(requestRole.Movie.Id);
                sessionActor.ActorRoles.Add(sessionRole);
            }*/

            // add or update associated roles
            foreach (var requestRole in requestActor.ActorRoles)
            {
                //var sessionRole = requestRole.Id == 0 ? new Role() : session.Get<Role>(requestRole.Id);
                var sessionRole = requestRole.Id == 0 ? new Role() : sessionActor.ActorRoles.FirstOrDefault(r => r.Id == requestRole.Id);
                sessionRole.Name = requestRole.Name;
                sessionRole.Actor = sessionActor;
                sessionRole.Movie = session.Get<Movie>(requestRole.Movie.Id);
                sessionActor.ActorRoles.Add(sessionRole);
            }

            // remove no longer associated roles
            var requestRoleIds = new HashSet<int>(requestActor.ActorRoles.Select(r => r.Id));
            foreach (var removedRole in sessionActor.ActorRoles.Where(r => !requestRoleIds.Contains(r.Id)).ToArray()) {
                sessionActor.ActorRoles.Remove(removedRole);
            }

            session.Transaction.Commit();
            ViewBag.Movies = session.Query<Movie>();

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
