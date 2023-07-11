using DotNetCore_Redis.Models;
using DotNetCore_Redis.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_Redis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ICacheService _cacheService;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICacheService cacheService)
        {
            _logger = logger;
            _cacheService = cacheService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("redis")]
        public async Task<IActionResult> Get(string key)
        {
            return Ok(await _cacheService.GetValueAsync(key));
        }

        [HttpPost("redis")]
        public async Task<IActionResult> Post([FromBody] CacheModel model)
        {
            await _cacheService.SetValueAsync(model.Key, model.Value);
            return Ok();
        }
        [HttpDelete("redis")]
        public async Task<IActionResult> Delete(string key)
        {
            await _cacheService.Clear(key);
            return Ok();
        }
    }
}