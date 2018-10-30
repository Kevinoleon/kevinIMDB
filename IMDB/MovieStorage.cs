using IMDB.Models;
using System.Collections.Generic;

namespace IMDB
{
    public class MovieStorage
    {
        public ISet<Movie> MovieList { get; set; }
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
            return null;
        }
        public static ISet<Movie> GetByName(string name, int pageIndex, int PageSize)
        {
            return null;
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