using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prometheus.Client;
using Prometheus.Client.Abstractions;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IMetricFactory _metricFactory;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IMetricFactory metricFactory, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _metricFactory = metricFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var metricFlags = MetricFlags.None;
            metricFlags |= MetricFlags.IncludeTimestamp;

            var gauge = _metricFactory.CreateGauge("example", "Sample metric", metricFlags, labelNames: new []{"instance","region"});
            gauge.WithLabels(new []{"local","europe"}).Set(100);

            return Ok();
        }
    }
}
