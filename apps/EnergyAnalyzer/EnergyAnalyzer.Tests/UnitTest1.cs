using System.Linq;
using EnergyAnalyzer.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace EnergyAnalyzer.Tests
{
    public class WeatherForecastControllerTests
    {
        private readonly WeatherForecastController _controller;
        private readonly Mock<ILogger<WeatherForecastController>> _loggerMock;

        public WeatherForecastControllerTests()
        {
            _loggerMock = new Mock<ILogger<WeatherForecastController>>();
            _controller = new WeatherForecastController(_loggerMock.Object);
        }

        [Fact]
        public void Get_ReturnsWeatherForecasts()
        {
            // Arrange
            // Setup is done in the constructor

            // Act
            var result = _controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
            foreach (var forecast in result)
            {
                Assert.NotNull(forecast);
                Assert.True(forecast.TemperatureC >= -20 && forecast.TemperatureC <= 55);
                Assert.True(WeatherForecastController.Summaries.Contains(forecast.Summary));
            }
        }
    }
}
