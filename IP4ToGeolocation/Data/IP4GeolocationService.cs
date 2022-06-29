using MaxMind.GeoIP2;
using MaxMind.GeoIP2.Exceptions;
using MaxMind.GeoIP2.Responses;

namespace IP4ToGeolocation.Data
{
    public class IP4GeolocationService
    {
        private string _dbFileLocation { get; set; }
        public IP4GeolocationService(IConfiguration configuration)
        {
            var section = configuration.GetSection("DbLocation");
            if(!string.IsNullOrEmpty(section.Value))
            {
                _dbFileLocation = section.Value;
            }
        }

        public Task<CityResponse?> GetGeolocationAsync(string ip4)
        {
            try
            {
                using (var reader = new DatabaseReader(_dbFileLocation))
                {
                    var city = reader.City(ip4);
                    return Task.FromResult<CityResponse?>(city);
                }
            }
            catch(Exception)
            {
                return Task.FromResult<CityResponse?>(null);
            }
            
        }
    }
}