using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using Nancy;
using ProjectTea.DataProviders;
using ProjectTea.Interfaces;

namespace ProjectTea.Modules
{
    public class MoodModule : NancyModule
    {
        private readonly IMoodRepository moodRepository = new MoodRepository();
        public MoodModule(IMoodRepository _moodRepository)
        {
            moodRepository = _moodRepository;

            //Routes
            Get["/mood"] = args =>
            {
                var moodList = moodRepository.GetAll();

                return Response.AsJson(moodList);
            };
        }
    }
}