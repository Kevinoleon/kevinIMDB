using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public String NameDto { get; set; }
        public int ActorId { get; set; }
        public int MovieId { get; set; }
    }
}