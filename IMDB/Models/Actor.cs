using System;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Actor
    {

        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public int age { get
            {
                TimeSpan i = DateTime.Today - DateOfBirth;
                return i.Days / 365;            
        }
         }
        public string  Nationality { get; set; }


    }
}