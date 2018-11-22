using System;

namespace IMDB.Models
{
    public class Role : Entity
    {
        public override Type EntityType
        {
            get { return typeof(Role); }
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