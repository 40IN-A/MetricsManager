using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly ValuesHolder holder;

        public CrudController(ValuesHolder holder)
        {
            this.holder = holder;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] WeatherForecastDto weatherForecastDto)
        {
            WeatherForecast weatherForecast = new WeatherForecast(weatherForecastDto.Date, weatherForecastDto.TemperatureC);
            holder.Values.Add(weatherForecast);
            return Ok();
        }

        [HttpGet("reads")]
        public IActionResult Reads()
        {
            return Ok(holder.Values);
        }

        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime? firstDate, [FromQuery] DateTime? secondDate)
        {
            if (!firstDate.HasValue)
            {
                firstDate = DateTime.MinValue;
            }
            if (!secondDate.HasValue)
            {
                secondDate = DateTime.MaxValue;
            }

            var value = from weatherForecast in holder.Values
                        where weatherForecast.Date >= firstDate.Value && weatherForecast.Date <= secondDate.Value
                        select weatherForecast;

            return Ok(value);
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime date, [FromQuery] int newTemperatureC)
        {
            foreach(var value in holder.Values)
            {
                if(date == value.Date)
                {
                    value.TemperatureC = newTemperatureC;
                }
            }

            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime firstDate, [FromQuery] DateTime secondDate)
        {
            foreach (var value in holder.Values.ToList())
            {
                if (value.Date >= firstDate && value.Date <= secondDate)
                {
                    holder.Values.Remove(value);
                }
            }
            return Ok();
        }

    }
}
