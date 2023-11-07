namespace BuberDinner.Domain.BillAggregates.ValueObjects;

public class Price
{
    private Price()
    {
    }

    public required float Amount { get; init; }
    public required Currency Currency { get; init; }

    public Price Create(float amount, Currency currency)
    {
        return new Price
        {
            Amount = amount,
            Currency = currency
        };
    }
}