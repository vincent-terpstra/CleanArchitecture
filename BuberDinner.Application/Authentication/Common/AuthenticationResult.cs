using BuberDinner.Domain.UserAggregates.Entities;

namespace BuberDinner.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);