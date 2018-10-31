using IMDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace IMDB
{
    public class MovieStorage
    {
        public static ISet<Movie> MovieList = new HashSet<Movie>();
        public Movie ClonedMovie { get; set; }

        //public MovieStorage()
        //{
        //    ClonedMovie = new Movie("","","");

            
        //}

        private static Movie Clone(Movie source)
        {
            Movie clon = new Movie();
            clon.OriginalTitle = source.OriginalTitle;
            clon.ReleaseDate = source.ReleaseDate;
            clon.Country = source.Country;
            return clon;
        }
        public static ISet<Movie> GetAll()
        {
            var result = new HashSet<Movie>(MovieList.Select(Clone));
            return result;
        }
        public static IList<Movie> GetByName(string name, int pageIndex, int PageSize)
        {

            return MovieList.Where(m => m.OriginalTitle == name).OrderBy(m => m.OriginalTitle).ThenBy(m => m.ReleaseDate).Skip(PageSize * pageIndex).Take(PageSize).Select(Clone).ToList();
        }
        public static ISet<Movie> GetById(int id)
        {
            return null;
        }
        public static ISet<Movie> Save(Movie updatedMovie)
        {
            return null;
        }
        public static ISet<Movie> Delete(int id)
        {
            return null;
        }


    }
}