namespace CityInfo.Models;

public class PointOfInterestDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public int NumberOfPointOfInterest
    {
        get { return PointsOfInterest.Count; }
    }

    public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();
}