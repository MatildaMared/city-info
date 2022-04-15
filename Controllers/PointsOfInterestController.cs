using AutoMapper;
using CityInfo.Models;
using CityInfo.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers;

[Route("/api/cities/{cityId}/pointsofinterest")]
[ApiController]
public class PointsOfInterestController : ControllerBase
{
    private readonly ILogger<PointsOfInterestController> _logger;
    private readonly IMailService _mailservice;
    private readonly ICityInfoRepository _cityInfoRepository;
    private readonly IMapper _mapper;

    public PointsOfInterestController(ILogger<PointsOfInterestController> logger, IMailService mailService,
        ICityInfoRepository cityInfoRepository, IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mailservice = mailService ?? throw new ArgumentNullException(nameof(mailService));
        _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointsOfInterest(int cityId)
    {
        if (!await _cityInfoRepository.CityExistsAsync(cityId))
        {
            _logger.LogInformation($"City with id {cityId} was not found when accessing points of interest.");
            return NotFound();
        }

        var pointsOfInterestForCity = await _cityInfoRepository.GetPointsOfInterestForCityAsync(cityId);
        return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForCity));
    }

    [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
    public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(int cityId, int pointOfInterestId)
    {
        if (!await _cityInfoRepository.CityExistsAsync(cityId))
        {
            _logger.LogInformation($"City with id {cityId} was not found when accessing points of interest.");
            return NotFound();
        }

        var pointOfInterest = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestId);

        if (pointOfInterest == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<PointOfInterestDto>(pointOfInterest));
    }

    // [HttpPost]
    // public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId,
    //     PointOfInterestForCreationDto pointOfInterest)
    // {
    //     var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
    //     if (city == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     var maxPointOfInterestId = _citiesDataStore.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);
    //
    //     var finalPointOfInterest = new PointOfInterestDto()
    //     {
    //         Id = ++maxPointOfInterestId,
    //         Name = pointOfInterest.Name,
    //         Description = pointOfInterest.Description
    //     };
    //
    //     city.PointsOfInterest.Add(finalPointOfInterest);
    //
    //     return CreatedAtRoute("GetPointOfInterest", new
    //         {
    //             cityId = cityId,
    //             pointOfInterestId = finalPointOfInterest.Id
    //         },
    //         finalPointOfInterest);
    // }
    //
    // [HttpPut("{pointofinterestid}")]
    // public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId,
    //     PointOfInterestForUpdateDto pointOfInterest)
    // {
    //     var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
    //     if (city == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
    //     if (pointOfInterestFromStore == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     pointOfInterestFromStore.Name = pointOfInterest.Name;
    //     pointOfInterestFromStore.Description = pointOfInterest.Description;
    //
    //     return NoContent();
    // }
    //
    // [HttpPatch("{pointofinterestid}")]
    // public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId,
    //     JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
    // {
    //     var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
    //     if (city == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
    //     if (pointOfInterestFromStore == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
    //     {
    //         Name = pointOfInterestFromStore.Name,
    //         Description = pointOfInterestFromStore.Description
    //     };
    //
    //     patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);
    //
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(ModelState);
    //     }
    //
    //     if (!TryValidateModel(pointOfInterestToPatch))
    //     {
    //         return BadRequest(ModelState);
    //     }
    //
    //     pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
    //     pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;
    //
    //     return NoContent();
    // }
    //
    // [HttpDelete("{pointOfInterestId}")]
    // public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
    // {
    //     var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
    //     if (city == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
    //     if (pointOfInterestFromStore == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     city.PointsOfInterest.Remove(pointOfInterestFromStore);
    //     _mailservice.Send(
    //         "Point of interest deleted.",
    //         $"Point of interest {pointOfInterestFromStore.Name} with id {pointOfInterestFromStore.Id} was deleted.");
    //     return NoContent();
    // }
}