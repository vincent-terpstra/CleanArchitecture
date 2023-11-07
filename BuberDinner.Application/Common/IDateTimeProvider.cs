namespace BuberDinner.Application.Common;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}