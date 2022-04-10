using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers;

[ApiController]
public class CitiesController : ControllerBase
{
    [HttpGet("api/cities")]
    public JsonResult GetCities()
    {
        return new JsonResult(
            new List<object>
            {
                new { id = 1, name = "New York City" },
                new { id = 2, name = "San Francisco" }
            });
    }
}