using System;

namespace MetricsManager
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public WeatherForecast(DateTime date, int temperatureC)
        {
            Date = date;
            TemperatureC = temperatureC;
        }
    }
}
