using AutoMapper;
using CityInfo.Models;
using CityInfo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly ICityInfoRepository _cityInfoRepository;
    private readonly IMapper _mapper;

    public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
    {
        _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities()
    {
        var cityEntities = await _cityInfoRepository.GetCitiesAsync();

        return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
    }

    [HttpGet("{id}")]
    public ActionResult<CityDto> GetCity(int id)
    {
        // var cityToReturn = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == id);
        //
        // if (cityToReturn == null)
        // {
        //     return NotFound();
        // }
        //
        // return Ok(cityToReturn);
        return Ok();
    }
}