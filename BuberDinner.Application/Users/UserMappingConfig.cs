using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Domain.UserAggregates.Entities;
using Mapster;

namespace BuberDinner.Application.Users;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterCommand, User>();
    }
}