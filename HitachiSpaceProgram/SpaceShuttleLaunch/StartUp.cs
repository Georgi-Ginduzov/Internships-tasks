using SpaceShuttleLaunch.Core;
using SpaceShuttleLaunch.Core.Contracts;

namespace SpaceShuttleLaunch
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new WeatherEngine("C:\\Users\\Asus\\source\\repos\\Internships-tasks\\HitachiSpaceProgram\\SpaceShuttleLaunch\\Utilities\\InputFiles\\Test.csv");
            engine.Run();
        }
    }
}
