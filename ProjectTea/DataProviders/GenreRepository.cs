using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTea.Interfaces;
using ProjectTea.Models;

namespace ProjectTea.DataProviders
{
    public class GenreRepository : IGenreRepository
    {
      public  List<Genre> GetAll()
      {
          var genres = new List<Genre>
          {
              new Genre {Name = "Disco"},
              new Genre {Name = "Jazz"},
              new Genre {Name = "Rock"},
          new Genre { Name = "Psychedelic Rock" },
          };


    return genres;        
}


    }
}