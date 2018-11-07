using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class ActorController : Controller
    {
        //private const int PageSize = 5;

        // GET: Actor
        public ActionResult Index(string searchString)
        {
            //string searchString = id;
            ISet<Actor> actors = new HashSet<Actor>();
            if (!String.IsNullOrEmpty(searchString))
            {
                actors = ActorStorage.GetByName(searchString);
            }
            else
            {
                actors = ActorStorage.GetAll();
            }
            return View(actors);
        


            //---------------version sergio-----------------    
            //var pageInfo = new ActorPageInfo
            //{
            //    PageItems = ActorStorage.GetByName(query, pageIndex ?? 0, PageSize),
            //    PageIndex = pageIndex ?? 0,
            //    PageCount = ActorStorage.GetCount() / PageSize + 1,
            //    SearchCriteria = query
            //};

            //return View("edit", pageInfo);
            //-------------------------------------------------
            
        }

        // GET: Actor/Details/5
        public ActionResult Details(int id)
        {
            var Actor = ActorStorage.GetById(id);
            return View(Actor);
        }

        // GET: Actor/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Actor/Create
        [HttpPost]
        public ActionResult Create(Actor newActor)
        {
            
            ActorStorage.Save(newActor);            
            return RedirectToAction("Index");
        }

        // GET: Actor/Edit/5
        public ActionResult Edit(int id)
        {
            var ActortoEdit = ActorStorage.GetById(id);
            return View(ActortoEdit);
        }

        // POST: Actor/Edit/5
        [HttpPost]
        public ActionResult Edit(Actor actorToEdit)
        {

            ActorStorage.Save(actorToEdit);

            return RedirectToAction("Index");
            
        }

        // GET: Actor/Delete/5
        public ActionResult Delete(int id)
        {
            var ActortoEdit = ActorStorage.GetById(id);
            return View(ActortoEdit);
        }

        // POST: Actor/Delete/5
        [HttpPost]
        public ActionResult Delete(Actor actorToDelete)
        {
            ActorStorage.Delete(actorToDelete.Id);
            return RedirectToAction("Index");
        }
    }
}
