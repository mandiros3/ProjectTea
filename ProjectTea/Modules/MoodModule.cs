
using Nancy;
using ProjectTea.DataProviders;
using ProjectTea.Interfaces;
using ProjectTea.Models;

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

                //return Response.AsJson(moodList);
                return View["Views/Pages/Mood", moodList];
            };

            Get["/mood/{id:int}"] = args =>
            {
                Mood mood = moodRepository.Get(args.id);
                return mood != null ? Response.AsJson(mood) : HttpStatusCode.NotFound;

            };
        }
    }
}