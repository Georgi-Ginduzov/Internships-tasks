using SpaceShuttleLaunch.Core;
using SpaceShuttleLaunch.Core.Contracts;

namespace SpaceShuttleLaunch
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new SpaceMissionEngine();
            engine.Run();
        }
    }
}
