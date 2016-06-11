﻿using System.Collections.Generic;
using ProjectTea.Models;

namespace ProjectTea.Interfaces
{
    public interface ITrackRepository
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