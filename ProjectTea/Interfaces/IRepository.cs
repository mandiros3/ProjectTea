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
        /*
        Track Get(int id);
        Track AddTrack(Track track);
        Task<Track> UpdateTrack(Track track);
        bool Delete(int id);
        */
    }
}