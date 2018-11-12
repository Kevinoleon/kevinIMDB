using System;

namespace IMDB.Models
{
    public abstract class Entity
    {
        public int Id
        {
            get;
            set;
        }

        public abstract Type EntityType
        {
            get;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            if (this.Id == 0)
            {
                return false;
            }

            Entity other = obj as Entity;
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id && this.EntityType == other.EntityType;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() + this.EntityType.GetHashCode();
        }
    }
}