using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using ProjectTea.Interfaces;
using ProjectTea.Models;

namespace ProjectTea.Modules
{
    public class MainModule : NancyModule
    {
        private readonly IRepository _trackRepository;
        
        //Todo Refactor Later
        public MainModule( IRepository trackRepository)
        {
            _trackRepository = trackRepository;

            //Routes
            Get["/"] = args =>
            {
                return Response.AsJson(_trackRepository.GetAll());
            };
        }

    }


  
}