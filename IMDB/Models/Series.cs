using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Series : Entity
    {
        public override Type EntityType
        {
            get { return typeof(Series); }
        }

        private ISet<Chapter> chapterList;

        [Required]
        public virtual string OriginalTitle { get; set; }
        [Required]
        public virtual string Description { get; set; }
        [Required]
        public virtual DateTime ReleaseDate { get; set; }
        [Required]
        public virtual string Country { get; set; }

        public virtual ISet<Chapter> Chapters {
            get { return chapterList ?? (chapterList = new HashSet<Chapter>()); }
            set { chapterList = value; }
        }

    }
}