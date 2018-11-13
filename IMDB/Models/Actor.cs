using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Actor: Entity
    {
        private ISet<MovieRole> movieRoles;

        public override Type EntityType
        {
            get { return typeof(Actor); }
        }
        public virtual string Name { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime DateOfBirth { get; set; }
        public virtual int age { get
            {
                TimeSpan i = DateTime.Today - DateOfBirth;
                return i.Days / 365;            
        }
         }
        public virtual string  Nationality { get; set; }

        [Display(Name = "Roles")]
        public virtual ISet<MovieRole> MovieRoles
        {
            get
            {
                if (movieRoles == null)
                {
                    movieRoles = new HashSet<MovieRole>();
                }

                return movieRoles;
            }
            set
            {
                movieRoles = value;
            }
        }


    }
}