using CityInfo.Models;

namespace CityInfo;

public class CitiesDataStore
{
    public List<CityDto> Cities { get; set; }
    public static CitiesDataStore Current { get; } = new CitiesDataStore();

    public CitiesDataStore()
    {
        Cities = new List<CityDto>()
        {
            new CityDto()
            {
                Id = 1,
                Name = "New York City",
                Description = "The one with the big park"
            },
            new CityDto()
            {
                Id = 2,
                Name = "Paris",
                Description = "The one with the big tower"
            },
            new CityDto()
            {
                Id = 3,
                Name = "San Francisco",
                Description = "The one with the red bridge"
            }
        };
    }
}