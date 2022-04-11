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
                Description = "The one with the big park",
                PointsOfInterest = new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto()
                    {
                        Id = 9,
                        Name = "Central park",
                        Description = "It's a big and famous park"
                    },
                    new PointOfInterestDto()
                    {
                        Id = 10,
                        Name = "Museum of Modern Art",
                        Description = "A famous art museum located on manhattan."
                    }
                }
            },
            new CityDto()
            {
                Id = 2,
                Name = "Paris",
                Description = "The one with the big tower",
                PointsOfInterest = new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto()
                    {
                        Id = 5,
                        Name = "Eiffel Tower",
                        Description = "A wrought iron lattice tower on the Champs de Mars."
                    },
                    new PointOfInterestDto()
                    {
                        Id = 6,
                        Name = "The Louvre",
                        Description = "The world's largest museum."
                    }
                }
            },
            new CityDto()
            {
                Id = 3,
                Name = "San Francisco",
                Description = "The one with the red bridge",
                PointsOfInterest = new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto()
                    {
                        Id = 7,
                        Name = "The Golden Gate Bridge",
                        Description = "A huge red bridge that is super famous."
                    },
                    new PointOfInterestDto()
                    {
                        Id = 8,
                        Name = "Alcatraz",
                        Description = "A prison on an island in the ocean."
                    }
                }
            }
        };
    }
}