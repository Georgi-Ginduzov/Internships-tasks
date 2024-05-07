using SpaceShuttleLaunch.Core.Contracts;
using SpaceShuttleLaunch.Models;
using SpaceShuttleLaunch.Repositories;

namespace SpaceShuttleLaunch.Core
{
    public class SpaceMissionController : ISpaceMissionController
    {
        private SpaceportRepository spaceports;
        private WeatherForecastsRepository forecasts;
        
        public SpaceMissionController()
        {
            spaceports = new SpaceportRepository();
            forecasts = new WeatherForecastsRepository();
        }


        public void AddSpaceport(string location) 
        {
            var spaceport = new Spaceport();
            spaceport.LocationName = location;
            
        }

        // Distance to the equator??
        // CompareTo
    }
}