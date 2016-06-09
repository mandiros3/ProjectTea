using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using ProjectTea.DataProviders;
using ProjectTea.Interfaces;

namespace ProjectTea.Modules
{
    public class DecadeModule : NancyModule
    {
        private readonly IDecadeRepository decadeRepository = new DecadeRepository();

        public DecadeModule(IDecadeRepository _decadeRepository)
        {
            decadeRepository = _decadeRepository;
            //Routes
            Get["/decade"] = args =>
            {
                var decadeList = decadeRepository.GetAll();
                return Response.AsJson(decadeList);
            };

        }


    }
}