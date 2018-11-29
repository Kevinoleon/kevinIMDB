using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class MovieDisplayDTO
    {
        public int Id { get; set; }
        public String OriginalTitle { get; set; }
        public String Country { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<String> Characters { get; set; }
    }
}