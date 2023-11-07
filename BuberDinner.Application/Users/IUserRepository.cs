using BuberDinner.Domain.UserAggregates.Entities;

namespace BuberDinner.Application.Users;

public interface IUserRepository
{
    public void Add(User user);

    public User? GetUserByEmail(string email);
}