using BuberDinner.Application.Users;
using BuberDinner.Domain.UserAggregates.Entities;

namespace BuberDinner.Infrastructure.Users;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new();

    public void Add(User user)
    {
        Users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return Users.SingleOrDefault(user => user.Email == email);
    }
}