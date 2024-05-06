namespace SpaceShuttleLaunch.IO.Contracts
{
    public interface IWriter
    {
        void Write(string message);
        void ClearData();
    }
}
