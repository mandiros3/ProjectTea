using System;
using System.Collections.Generic;
using ProjectTea.Models;

namespace ProjectTea.Interfaces
{
    public interface IMoodRepository
    {
        List<Mood> GetAll();
        Mood Get(int id);
        /*
Track Get(int id);

Task<Track> Update(Track track);
bool Delete(int id);
*/
    }
}