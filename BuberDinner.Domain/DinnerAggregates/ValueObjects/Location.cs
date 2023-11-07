namespace BuberDinner.Domain.DinnerAggregates.ValueObjects;

public class Location
{
    public required string Name { get; set; }
    public required string Address { get; set; }

    public float Latitude { get; init; }
    public float Longitude { get; init; }
}