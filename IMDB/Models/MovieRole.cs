using System;

namespace IMDB.Models
{
    public class MovieRole : Entity
    {
        public override Type EntityType
        {
            get { return typeof(MovieRole); }
        }

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