namespace BuberDinner.Domain.BillAggregates.ValueObjects;

public class Currency
{
    public static Currency USD = new() {Value = "USD"};

    private Currency()
    {
    }

    public required string Value { get; init; }
}