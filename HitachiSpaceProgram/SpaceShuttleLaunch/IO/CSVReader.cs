using SpaceShuttleLaunch.IO.Contracts;
using SpaceShuttleLaunch.Models;
using System.Globalization;

namespace SpaceShuttleLaunch.IO
{
    public abstract class CSVReader : IReader
    {
        public abstract string Read(string filePath);
    }
}
