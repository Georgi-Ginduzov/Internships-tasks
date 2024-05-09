namespace SpaceShuttleLaunch.Models.Contracts
{
    public interface IWeatherForecast
    {
        public int Date { get; set; }
        public int Lattitude { get; set; }
        public float Temperature { get; set; }
        public float WindSpeed { get; set; }
        public int Humidity { get; set; }
        public int Precipitation { get; set; }
        public string Lightning { get; set; }
        public string Clouds { get; set; }
    }
}
