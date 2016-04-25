using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ProjectTea.Models;

namespace ProjectTea.Interfaces
{
    public interface IRepository
    {
        List<Track> GetAll();
        Track Create(Track track);
        /*
        Track Get(int id);
        
        Task<Track> Update(Track track);
        bool Delete(int id);
        */
    }
}