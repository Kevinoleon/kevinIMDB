﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Movie : Entity
        {

            private ISet<MovieRole> movieRoles;

            public override Type EntityType
            {
                get { return typeof(Movie); }
            }
            public string OriginalTitle { get; set; }

            [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime ReleaseDate { get; set; }
            public string Country { get; set; }
            public ISet<MovieRole> MovieRoles
            {
                get { return movieRoles ?? (movieRoles = new HashSet<MovieRole>()); }
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