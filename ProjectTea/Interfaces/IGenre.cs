using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ProjectTea.Models;

namespace ProjectTea.Interfaces
{
    public interface IGenre
    {
        List<Genre> GetAll();
        Genre Create(Genre genre);
        
        Genre Get(int id);
        /*
        Task<Track> Update(Track track);
        bool Delete(int id);
        */
    }
}