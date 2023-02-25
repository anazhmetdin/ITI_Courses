using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1observer
{
    internal class WeatherData
    {
        public event EventHandler<WeatherDataEventArgs>? WeatherUpdate;

        private float humidity;
        private float pressure;
        private float temperature;

        public float Humidity
        {
            get { return humidity; }
            set {
                if (humidity != value)
                {
                    humidity = value;
                    OnMeasurementChange(new() { Humidity = this.Humidity, Pressure = this.Pressure, Temperature = this.Temperature });
                }
            }
        }
        public float Pressure
        {
            get { return pressure; }
            set
            {
                if (pressure != value)
                {
                    pressure = value;
                    OnMeasurementChange(new() { Humidity = this.Humidity, Pressure = this.Pressure, Temperature = this.Temperature });
                }
            }
        }
        public float Temperature
        {
            get { return temperature; }
            set
            {
                if (temperature != value)
                {
                    temperature = value;
                    OnMeasurementChange(new() { Humidity = this.Humidity, Pressure = this.Pressure, Temperature = this.Temperature });
                }
            }
        }

        public WeatherData(float humidity, float pressure, float temperature)
        {
            Humidity = humidity;
            Pressure = pressure;
            Temperature = temperature;
        }

        protected virtual void OnMeasurementChange(WeatherDataEventArgs e)
        {
            WeatherUpdate?.Invoke(this, e);
        }
    }


    public class WeatherDataEventArgs : EventArgs
    {
        public float Humidity { get; set; }
        public float Pressure { get; set; }
        public float Temperature { get; set; }
    }
}
