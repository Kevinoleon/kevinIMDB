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

        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime ReleaseDate { get; set; }

        public virtual string Country { get; set; }

        public virtual  ISet<Role> MovieRoles
        {
            get { return movieRoles ?? (movieRoles = new HashSet<Role>()); }
            set { movieRoles = value; }
        }

    }
    
}