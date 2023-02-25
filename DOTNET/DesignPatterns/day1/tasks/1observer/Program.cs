namespace _1observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeatherData wd = new(1,2,3);

            Screen screen1 = new("screen1");
            Screen screen2 = new("screen2");

            wd.Humidity = 5;

            wd.WeatherUpdate += screen1.Display!;
            wd.WeatherUpdate += screen2.Display!;

            wd.Humidity = -1;
            wd.Pressure = -1;
            wd.Temperature = -1;
        }
    }
}