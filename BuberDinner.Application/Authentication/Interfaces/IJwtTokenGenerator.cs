using BuberDinner.Domain.UserAggregates.Entities;

namespace BuberDinner.Application.Authentication.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}