using BuberDinner.Domain.UserAggregates.ValueObjects;

namespace BuberDinner.Domain.UserAggregates.Entities;

public class User
{
    public UserId Id { get; set; } = UserId.New();

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }
}