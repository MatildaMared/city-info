using CityInfo.Entities;

namespace CityInfo.Services;

public interface ICityInfoRepository
{
    Task<bool> CityExistsAsync(int cityId);
    Task<IEnumerable<City>> GetCitiesAsync();
    Task<IEnumerable<City>> GetCitiesAsync(string? name);
    Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest);
    Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId);
    Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId);
    Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest);
    void DeletePointOfInterest(PointOfInterest pointOfInterest);
    Task<bool> SaveChangesAsync();
}