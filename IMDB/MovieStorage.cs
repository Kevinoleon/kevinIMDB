using IMDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace IMDB
{
    public class MovieStorage
    {
        private static readonly ISet<Movie> movies = new HashSet<Movie>();

        //internal static int GetCount()
        //{
        //    return movies.Count;
        //}

        //public MovieStorage()
        //{
        //    ClonedMovie = new Movie("","","");


        //}

        private static Movie Clone(Movie sourceMovie)
        {
            Movie newMovie = new Movie();
            newMovie.Id = sourceMovie.Id;
            Map(sourceMovie, newMovie);
            return newMovie;
        }

        private static void Map(Movie sourceMovie, Movie destinationMovie)
        {
            destinationMovie.Country = sourceMovie.Country;
            destinationMovie.OriginalTitle = sourceMovie.OriginalTitle;
            destinationMovie.ReleaseDate = sourceMovie.ReleaseDate;
        }
        public static ISet<Movie> GetAll()
        {
            var result = new HashSet<Movie>(movies.Select(Clone));
            return result;
        }
        public static ISet<Movie> GetByName(string title/*, int pageIndex, int pageSize*/)
        {
            var result = new HashSet<Movie>(movies.Where(m => m.OriginalTitle == title)
                .OrderBy(m => m.OriginalTitle).ThenBy(m => m.Id).Select(Clone));
            return result;
            //return movies.Where(m => m.OriginalTitle == name).OrderBy(m => m.OriginalTitle).ThenBy(m => m.ReleaseDate).Skip(PageSize * pageIndex).Take(PageSize).Select(Clone).ToList();
        }
        public static Movie GetById(int id)
        {
            Movie Result = movies.Single(m => m.Id == id);
            return Clone(Result);
            //Where(m => m.Id == id)
            //.OrderBy(m => m.OriginalTitle).
            //ThenBy(m => m.ReleaseDate).
            //Skip(PageSize * pageIndex).
            //Take(PageSize)
            //.Select(Clone).ToList(); ;
        }
        public static void Save(Movie updatedMovie)
        {
            Movie storageMovie = movies.FirstOrDefault(m => m.Id == updatedMovie.Id);

            if (storageMovie != null)
            {
                Map(updatedMovie, storageMovie);

            }
            else
            {
                //updatedMovie.Id = movies.Max(m => m.Id) + 1;
                //updatedMovie.Id = movies.DefaultIfEmpty().Max(m => m==null ? 0:m.Id) + 1;
                //updatedMovie.Id = movies.DefaultIfEmpty().Max(m => m.Id? ) + 1;
                updatedMovie.Id = (movies.Count == 0 ? 0 : movies.Max(m => m.Id)) + 1;
                movies.Add(Clone(updatedMovie));
            }

        }
        public static void Delete(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                movies.Remove(movie);
            }
        }


    }
}