using SpaceShuttleLaunch.IO.Contracts;

namespace SpaceShuttleLaunch.IO
{
    public abstract class CSVReader : IReader
    {
        public abstract string Read(string filePath);
    }
}
