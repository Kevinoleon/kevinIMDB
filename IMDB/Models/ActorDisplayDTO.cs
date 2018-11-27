using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class ActorDisplayDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public int age { get; set; }
        public List<String> Roles { get; set; }
    }
}