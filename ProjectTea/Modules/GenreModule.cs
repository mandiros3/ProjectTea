using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using ProjectTea.Interfaces;
using ProjectTea.Models;

namespace ProjectTea.Modules
{
    public class GenreModule : NancyModule
    {
        private readonly IGenreRepository _genreRepository;
        public GenreModule(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;

            //Routes

            //TODO make all genres clickable links... clicking on disco link should get all songs where of discoID =Disco
            // Genre just be a viewmodel. I can put genre directly in the database rather than a genre Id
            // Explore both options, try them see which ones work best.
            Get["/genres"] = args =>
            {
              var genreList =  _genreRepository.GetAll();

                return Response.AsJson(genreList);
            };

            Post["/tracks"] = args =>
            {
                var newGenre = this.Bind<Genre>();
                var createdGenre = _genreRepository.Create(newGenre);
                return createdGenre != null ? Response.AsJson(createdGenre, HttpStatusCode.Created) : HttpStatusCode.InternalServerError;
            };

        }

    }
}