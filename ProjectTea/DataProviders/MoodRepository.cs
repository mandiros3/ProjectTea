using ProjectTea.Models;
using ProjectTea.Interfaces;
using System.Collections.Generic;


namespace ProjectTea.DataProviders
{
    public class MoodRepository : IMoodRepository
    {
        public List<Mood> GetAll()
        {
            var moods = new List<Mood>
            {
                new Mood {Name = "Happy"},
                new Mood {Name = "Chill"},
                new Mood {Name = "Sad"},
                new Mood {Name = "Angry"},
            };
            return moods;
        }
    }
}