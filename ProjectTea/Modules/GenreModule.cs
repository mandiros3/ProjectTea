
using Nancy;
using Nancy.ModelBinding;
using ProjectTea.DataProviders;
using ProjectTea.Interfaces;
using ProjectTea.Models;

namespace ProjectTea.Modules
{//Todo: When I click on a spefic genre, it should perform a query between the id and the tracks that have that id. join()
    public class GenreModule : NancyModule
    {
        //Leave initialization just to be explicit
        private readonly IGenre _genreRepository = new GenreRepository();

        //Pass genreRepository as argument, to make it easier for testing.
        public GenreModule(IGenre genreRepository)
        {
            _genreRepository = genreRepository;

            //Routes

            //TODO make all genres clickable links... clicking on disco link should get all songs where of discoID =Disco
            // Genre just be a viewmodel. I can put genre directly in the database rather than a genre Id
            // Explore both options, try them see which ones work best.
            Get["/genres"] = args =>
            {
              var genreList =  _genreRepository.GetAll();
                return View["Views/Pages/Genre", genreList];
            };

            Get["/genres/{id:int}"] = args =>
            {
               Genre genre = genreRepository.Get(args.id);
                return genre != null ? Response.AsJson(genre) : HttpStatusCode.NotFound;

            };

            Post["/genres"] = args =>
            {
                var newGenre = this.Bind<Genre>();
                var createdGenre = genreRepository.Create(newGenre);

                return createdGenre != null ? Response.AsJson(createdGenre, HttpStatusCode.Created) : HttpStatusCode.InternalServerError;

            };

        }

    }
}