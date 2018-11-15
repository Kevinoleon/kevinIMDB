using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Movie : Entity
    {

        private ISet<Role> movieRoles;

        public override Type EntityType
        {
            get { return typeof(Movie); }
        }

        public virtual string OriginalTitle { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime ReleaseDate { get; set; }

        public virtual string Country { get; set; }

        public virtual  ISet<Role> MovieRoles
        {
            get { return movieRoles ?? (movieRoles = new HashSet<Role>()); }
            set { movieRoles = value; }
        }

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

    }
    
}