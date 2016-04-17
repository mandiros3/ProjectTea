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
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Mood { get; set; }

    }
}