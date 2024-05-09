using SpaceShuttleLaunch.Models.Contracts;
using SpaceShuttleLaunch.Repositories.Contracts;

namespace SpaceShuttleLaunch.Repositories
{
    public class SpaceportRepository : IRepository<ISpaceport>
    {
        private SortedSet<ISpaceport> models;

        public SpaceportRepository()
        {
            models = new SortedSet<ISpaceport>();
        }

        public IReadOnlyCollection<ISpaceport> Models => models;
        public IWeatherForecast MostSuitableLaunchDay
        {
            get => models.First().MostConvenientDayForLaunch;
        }

        public void Add(ISpaceport model)
        {
            
            models.Add(model);
        }

        public void Remove(ISpaceport model)
        {
            models.Remove(model);
        }
    }
}
