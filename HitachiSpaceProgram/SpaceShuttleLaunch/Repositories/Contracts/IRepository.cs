namespace SpaceShuttleLaunch.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(T model);

    }
}
