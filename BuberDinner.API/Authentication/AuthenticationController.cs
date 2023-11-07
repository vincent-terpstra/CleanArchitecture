using BuberDinner.Api.Common;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Authentication;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = Mapper.Map<RegisterCommand>(request);
        var registerResult = await Sender.Send(command);

        return OkOrProblem(registerResult, Mapper.Map<AuthenticationResponse>);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = Mapper.Map<LoginQuery>(request);
        var loginResult = await Sender.Send(query);

        return OkOrProblem(loginResult, Mapper.Map<AuthenticationResponse>);
    }
}