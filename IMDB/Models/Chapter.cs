using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Chapter: Entity
    {
        public override Type EntityType
        {
            get { return typeof(Chapter); }
        }
        [required]
        public string Name { get; set; }
        [required]
        public string Description { get; set; }
        [required]
        public DateTime ReleaseDate { get; set; }
        [required]
        public int Duration { get; set; }
        [required]
        public int Season { get; set; }
        [required]
        public int ChapterNumber { get; set; }


    }
}