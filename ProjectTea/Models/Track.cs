using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTea.Models
{
    public class Track
    {
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
       public int GenreId { get; set; }
     public int MoodId { get; set; }
    public int Year { get; set; }

    }
}