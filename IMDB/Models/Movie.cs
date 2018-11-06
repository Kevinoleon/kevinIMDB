using System;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Movie
        {
            public int Id { get; set; }
            public string OriginalTitle { get; set; }
            [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime ReleaseDate { get; set; }
            public string Country { get; set; }

        //public static int ContadorDeObj { get; set; }

        //public string Poster { get; set; }
        //public IList<Actor> Actores { get; set; }

        //public Movie(string Otitle, string rDate, string country)
        //{
        //    this.Id = System.Threading.Interlocked.Increment(ref Id);
        //    this.OriginalTitle = Otitle;
        //    this.ReleaseDate = rDate;
        //    this.Country = country;
        //}

        public class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}",
                    ApplyFormatInEditMode = true)]
            public DateTime DOB { get; set; }
            [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}",
                    ApplyFormatInEditMode = true)]
            public DateTime JoiningDate { get; set; }
        }
    }
    
}