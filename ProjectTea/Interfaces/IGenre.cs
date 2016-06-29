
using System.Collections.Generic;

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