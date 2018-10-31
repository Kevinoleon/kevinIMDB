namespace IMDB.Models
{
    public class Movie
        {
            public int? Id { get; set; }
            public string OriginalTitle { get; set; }
            public string ReleaseDate { get; set; }
            public string Country { get; set; }

            public static int ContadorDeObj { get; set; }

        //public string Poster { get; set; }
        //public IList<Actor> Actores { get; set; }

        //public Movie(string Otitle, string rDate, string country)
        //{
        //    this.Id = System.Threading.Interlocked.Increment(ref Id);
        //    this.OriginalTitle = Otitle;
        //    this.ReleaseDate = rDate;
        //    this.Country = country;
        //}
        }
    
}