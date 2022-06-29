using IP4ToGeolocation.Data;
using IP4ToGeolocation.Pages;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace IP4GeoLocationUnitTest
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDefault()
        {
            //Arrange
            using var ctx = new Bunit.TestContext();

            var myConfiguration = new Dictionary<string, string>
            {
                {"DbLocation", "../../../../IP4ToGeolocation/Db/GeoLite2-City.mmdb"}
            };
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
            ctx.Services.AddSingleton<IConfiguration>(config);
            ctx.Services.AddHttpContextAccessor();
            ctx.Services.AddSingleton<IP4GeolocationService>();
            //Act
            var cut = ctx.RenderComponent<FetchData>();
            var paraElm = cut.Find("p");

            //Assert
            paraElm.TextContent.MarkupMatches("No results found for the current IP");
        }

        [Test]
        public void TestExampleIP()
        {
            //Arrange
            using var ctx = new Bunit.TestContext();

            var myConfiguration = new Dictionary<string, string>
            {
                {"DbLocation", "../../../../IP4ToGeolocation/Db/GeoLite2-City.mmdb"}
            };

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
            ctx.Services.AddSingleton<IConfiguration>(config);
            ctx.Services.AddHttpContextAccessor();
            ctx.Services.AddSingleton<IP4GeolocationService>();
            //Act
            var service = ctx.Services.GetService<IP4GeolocationService>();
            var location = service.GetGeolocationAsync("121.121.121.121").Result;

            //Assert
            Assert.IsNotNull(location);
            Assert.AreEqual(3.1071, location.Location.Latitude);
            Assert.AreEqual(101.5526, location.Location.Longitude);
        }
    }
}