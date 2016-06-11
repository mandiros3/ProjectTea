﻿
using Nancy;
using ProjectTea.DataProviders;
using ProjectTea.Interfaces;
using ProjectTea.Models;

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

            Get["/decade/{id:int}"] = args =>
            {
                Decade decade= decadeRepository.Get(args.id);
                return decade != null ? Response.AsJson(decade) : HttpStatusCode.NotFound;

            };

        }


    }
}