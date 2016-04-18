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
       // public Genre Genre { get; set; }
       public string Genre { get; set; }
        // public Decade Decade { get; set; }
        public int Year { get; set; }
     public string Mood { get; set; }

    }
}