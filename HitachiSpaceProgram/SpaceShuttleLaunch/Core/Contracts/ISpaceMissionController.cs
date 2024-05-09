namespace SpaceShuttleLaunch.Core.Contracts
{
    public interface ISpaceMissionController
    {
        void FindMostSuitableSpaceportForecast(string filePath, string spaceportLocation);
    }
}
