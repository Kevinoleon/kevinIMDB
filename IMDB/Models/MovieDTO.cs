using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public String OriginalTitle { get; set; }
        public String Country { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<String> Roles { get; set; }
    }
}