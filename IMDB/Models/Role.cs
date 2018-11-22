using System;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{

    public class Role : Entity
    {
        public override Type EntityType
        {
            get { return typeof(Role); }
        }
        [Required]
        public virtual string Name
        {
            get;
            set;
        }

        public virtual Movie Movie
        {
            get;
            set;
        }

        public virtual Actor Actor
        {
            get;
            set;
        }
    }
}