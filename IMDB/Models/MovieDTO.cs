using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string OriginalTitle { get; set; }
        public string Country { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IList<RoleDTO> Characters { get; set; }
    }
}