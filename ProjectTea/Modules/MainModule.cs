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
                var trackList = _trackRepository.GetAll();
                return View["Views/Pages/Home", trackList];
            };

            Get["/tracks/{id}"] = args =>
            {
                return "Item " + args.id;
            };


            //Sent URL view ajax
            //Receive youtube url in Module
            // 1.a --Save in Database, returun updated model
            // 1.b Make API Call
            // send data to model (view)
            // Add additional tag: like genre, mood, comments
            // Add to db which will at to list,
            //Software done
            // Test
            //Fix bugs
            // Refactor.
        }

    }


  
}