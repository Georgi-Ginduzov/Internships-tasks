using SpaceShuttleLaunch.Core.Contracts;
using SpaceShuttleLaunch.IO;
using SpaceShuttleLaunch.IO.Contracts;

namespace SpaceShuttleLaunch.Core
{
    internal class WeatherEngine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ISpaceMissionController controller;

        public WeatherEngine()
        {
            reader = new CSVReader();
            writer = new CSVWriter();
            controller = new SpaceMissionController();
        }


        public void Run()
        {
            
        }
    }
}
