using SpaceShuttleLaunch.Core.Contracts;
using SpaceShuttleLaunch.IO;
using SpaceShuttleLaunch.Models;

namespace SpaceShuttleLaunch.Core
{
    public class SpaceMissionController : ISpaceMissionController
    {
        private Spaceport spaceport;
        public SpaceMissionController()
        {
            spaceport = new Spaceport();
        }

       
    }
}
