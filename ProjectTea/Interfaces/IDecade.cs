
using System.Collections.Generic;
using ProjectTea.Models;

namespace ProjectTea.Interfaces
{

    //todo cleanup names
    public interface IDecade
    {
        List<Decade> GetAll();
      
        Decade Get(int id);
        /*
      Task<Decade> Update(Decade decade);
      bool Delete(int id);
      */
    }
}