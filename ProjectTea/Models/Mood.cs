using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTea.Models
{
    public class Mood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Track> Tracks { get; set; }
    }
}