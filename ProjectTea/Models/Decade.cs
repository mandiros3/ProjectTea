
using System.Collections.Generic;

namespace ProjectTea.Models
{

    /// <summary>
    /// Returns the decade, TODO should have a function that returns the end only (1960 - 60s, 1950 -  50s)
    /// </summary>
    public class Decade
    {
            public int Id { get; set; }
            public int Year { get; set; }
            public string Description { get; set; }
            public List<Track> Tracks { get; set; }
      
    }
}