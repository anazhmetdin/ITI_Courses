using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1observer
{
    internal class Screen
    {
        public string Name { get; set; }

        public Screen(string name) { Name = name; }

        public void Display(object sender, WeatherDataEventArgs e)
        {
            if (sender is WeatherData wd && wd != null)
            {
                Console.WriteLine($"-------------");
                Console.WriteLine($"{Name}:");
                Console.WriteLine($"\tHumidity: {e.Humidity}");
                Console.WriteLine($"\tPressure: {e.Pressure}");
                Console.WriteLine($"\tTemperature: {e.Temperature}");
            }
        }
    }
}
