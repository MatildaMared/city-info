using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CitiesController : ControllerBase
{
    [HttpGet]
    public JsonResult GetCities()
    {
        return new JsonResult(CitiesDataStore.Current.Cities);
    }

    [HttpGet("{id}")]
    public JsonResult GetCity(int id)
    {
        return new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id));
    }
}