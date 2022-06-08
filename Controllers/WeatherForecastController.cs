using Microsoft.AspNetCore.Mvc;

namespace webapidotnet.Controllers;

[ApiController]
[Route("api/[controller]")]//ruta dinamica de controlador, en este caso WeatherForecast
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;


    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    // [Route("[action]")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogDebug("Retornando lista de weather forecast");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    // [HttpGet(Name = "GetWeatherForecast2")]
    // [Route("get/weatherforecast")]//ruta personalizada
    // [Route("get/weatherforecast2")]
    // [Route("[action]")]//ruta dinamica, toma como ruta el nombre del metodo en este caso get2
    // public IEnumerable<WeatherForecast> Get2()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateTime.Now.AddDays(index),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index) 
    {
        return Ok(index);
    }
}
