using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class ActorDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int age
        {
            get
            {
                TimeSpan i = DateTime.Today - DateOfBirth;
                return i.Days / 365;
            }
        }
        //public int age { get; set; }
        public IList<RoleDTO> Roles { get; set; }
    }
}