namespace SpaceShuttleLaunch.Models.Contracts
{
    public interface ISpaceport
    {
        string LocationName { get; }
        double Latitude { get; }

        double DistanceToEquator();
    }
}