using SpaceShuttleLaunch.Models.Contracts;
using SpaceShuttleLaunch.Repositories.Contracts;
using SpaceShuttleLaunch.Utilities.Messages;

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
            get
            {
                if (!models.Any())
                {
                    throw new InvalidOperationException(ExceptionMessages.NoForecastsAvailable);
                }
                return models.First().MostConvenientDayForLaunch;
            }
        }

        public void Add(ISpaceport model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), ExceptionMessages.ModelCannotBeNull);
            }
            models.Add(model);
        }

        public void Remove(ISpaceport model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), ExceptionMessages.ModelCannotBeNull);
            }
            models.Remove(model);
        }
    }
}
