using System;
using System.Collections.Generic;
using ProjectTea.Models;
using ProjectTea.Interfaces;
namespace ProjectTea.Interfaces
{

    //todo cleanup names
    public interface IDecadeRepository
    {
        List<Decade> GetAll();
        /*
        Track Get(int id);
        
        Task<Track> Update(Track track);
        bool Delete(int id);
        */
    }
}