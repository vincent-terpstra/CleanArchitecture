using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Interfaces;
using BuberDinner.Application.Users;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // validate the user exists
        if (_userRepository.GetUserByEmail(query.Email) is not { } user)
            return Errors.Authentication.InvalidCredentials;

        // ensure the password is correct
        if (user.Password != query.Password)
            return Errors.Authentication.InvalidCredentials;

        // create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}