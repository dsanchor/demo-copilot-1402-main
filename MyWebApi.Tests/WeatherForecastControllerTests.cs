using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

using MyWebApi;

public class WeatherForecastControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public WeatherForecastControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetSortedWeatherForecast_ReturnsSortedForecast()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/weatherforecast/sorted");

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        var forecasts = JsonConvert.DeserializeObject<WeatherForecast[]>(responseString);

        // Assert
        Assert.True(forecasts.SequenceEqual(forecasts.OrderBy(f => f.TemperatureC)));
    }

    [Fact]
    public async Task GetWeatherForecast_ReturnsFiveDayForecast()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/weatherforecast");

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        var forecasts = JsonConvert.DeserializeObject<WeatherForecast[]>(responseString);

        // Assert
        Assert.Equal(5, forecasts.Length);
    }

    [Fact]
    public async Task AllForecastsHaveSummary()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/weatherforecast");

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        var forecasts = JsonConvert.DeserializeObject<WeatherForecast[]>(responseString);

        // Assert
        Assert.All(forecasts, forecast => Assert.NotNull(forecast.Summary));
    }

    record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}