using IMDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace IMDB
{
    public class ActorStorage
    {
        private static readonly ISet<Actor> actors = new HashSet<Actor>();

        //internal static int GetCount()
        //{
        //    return actors.Count;
        //}

        //public ActorStorage()
        //{
        //    ClonedActor = new Actor("","","");


        //}

        private static Actor Clone(Actor sourceActor)
        {
            Actor newActor = new Actor();
            newActor.Id = sourceActor.Id;
            Map(sourceActor, newActor);
            return newActor;
        }

        private static void Map(Actor sourceActor, Actor destinationActor)
        {
            destinationActor.Nationality = sourceActor.Nationality;
            destinationActor.Name = sourceActor.Name;
            destinationActor.DateOfBirth = sourceActor.DateOfBirth;
        }
        public static ISet<Actor> GetAll()
        {
            var result = new HashSet<Actor>(actors.Select(Clone));
            return result;
        }
        public static ISet<Actor> GetByName(string title/*, int pageIndex, int pageSize*/)
        {
            var result = new HashSet<Actor>(actors.Where(m => m.Name.ToLower().Contains(title.ToLower())).
                OrderBy(m => m.Name).ThenBy(m => m.Id).Select(Clone));
            return result;
            //return actors.Where(m => m.Name == name).OrderBy(m => m.Name).ThenBy(m => m.DateOfBirth).Skip(PageSize * pageIndex).Take(PageSize).Select(Clone).ToList();
        }
        public static Actor GetById(int id)
        {
            Actor Result = actors.Single(m => m.Id == id);
            return Clone(Result);
            //Where(m => m.Id == id)
            //.OrderBy(m => m.Name).
            //ThenBy(m => m.DateOfBirth).
            //Skip(PageSize * pageIndex).
            //Take(PageSize)
            //.Select(Clone).ToList(); ;
        }
        public static void Save(Actor updatedActor)
        {
            Actor storageActor = actors.FirstOrDefault(m => m.Id == updatedActor.Id);

            if (storageActor != null)
            {
                Map(updatedActor, storageActor);

            }
            else
            {
                //updatedActor.Id = actors.Max(m => m.Id) + 1;
                //updatedActor.Id = actors.DefaultIfEmpty().Max(m => m==null ? 0:m.Id) + 1;
                //updatedActor.Id = actors.DefaultIfEmpty().Max(m => m.Id? ) + 1;
                updatedActor.Id = (actors.Count == 0 ? 0 : actors.Max(m => m.Id)) + 1;
                actors.Add(Clone(updatedActor));
            }

        }
        public static void Delete(int id)
        {
            var actor = actors.FirstOrDefault(m => m.Id == id);
            if (actor != null)
            {
                actors.Remove(actor);
            }
        }


    }
}