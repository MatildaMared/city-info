using CityInfo.DbContexts;
using CityInfo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Services;

public class CityInfoRepository : ICityInfoRepository
{
    private readonly CityInfoContext _context;

    public CityInfoRepository(CityInfoContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    // Returns all cities. Async method, cities ordered by name
    public async Task<IEnumerable<City>> GetCitiesAsync()
    {
        return await _context.Cities.OrderBy(c => c.Name).ToListAsync();
    }

    // Returns a single city. A boolean decides if to include points of interests or not
    public async Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest)
    {
        if (includePointsOfInterest)
        {
            return await _context.Cities.Include(c => c.PointsOfInterest).Where(c => c.Id == cityId)
                .FirstOrDefaultAsync();
        }

        return await _context.Cities.Where(c => c.Id == cityId).FirstOrDefaultAsync();
    }

    // Returns points of interest for a city
    public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId)
    {
        return await _context.PointsOfInterest.Where(p => p.CityId == cityId).ToListAsync();
    }

    // Returns a single point of interest
    public async Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId)
    {
        return await _context.PointsOfInterest.Where(p => p.CityId == cityId && p.Id == pointOfInterestId)
            .FirstOrDefaultAsync();
    }
}