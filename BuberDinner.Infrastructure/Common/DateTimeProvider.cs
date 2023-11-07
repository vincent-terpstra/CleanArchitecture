using BuberDinner.Application.Common;

namespace BuberDinner.Infrastructure.Common;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}