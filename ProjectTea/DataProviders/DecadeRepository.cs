using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using ProjectTea.Models;
using ProjectTea.Interfaces;

namespace ProjectTea.DataProviders
{
    public class DecadeRepository : IDecadeRepository
    {
        public List<Decade> GetAll()
        {
            var decades = new List<Decade>
          {
              new Decade {Year = 1960},
              new Decade {Year = 1970},
              new Decade {Year = 1980},
              new Decade { Year = 1990 },
          };
            return decades;
        }

    }
}