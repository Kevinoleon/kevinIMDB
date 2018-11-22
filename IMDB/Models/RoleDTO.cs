using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Actor { get; set; }
        public String Movie { get; set; }
    }
}