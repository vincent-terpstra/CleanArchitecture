using BuberDinner.Api.Common.Http;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDinner.Api.Common;

[ApiController]
[Authorize]
public abstract class ApiControllerBase : ControllerBase
{
    private IMapper? _mapper;
    private ISender? _sender;
    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetRequiredService<IMapper>();


    /// <summary>
    ///     Takes a list of Error objects returns a Problem IActionResult
    /// </summary>
    /// <param name="errors"></param>
    /// <returns></returns>
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count() is 0)
        {
            return Problem();
        }

        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);
        }

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        return Problem(errors[0]);
    }

    private IActionResult Problem(Error firstError)
    {
        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: firstError.Description);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelState = new ModelStateDictionary();
        foreach (var error in errors)
        {
            modelState.AddModelError(error.Code, error.Description);
        }

        return ValidationProblem(modelState);
    }

    /// <summary>
    ///     Maps an ErrorOr to either an OK result or a Problem Result
    /// </summary>
    /// <param name="input">The ErrorOr object of type input</param>
    /// <param name="map">A Function that maps inputs type to output</param>
    /// <typeparam name="TIn">The input type</typeparam>
    /// <typeparam name="TResult">The resultant object type</typeparam>
    /// <returns>IActionResult of type OK or Problem</returns>
    protected IActionResult OkOrProblem<TIn, TResult>(ErrorOr<TIn> input, Func<TIn, TResult> map)
    {
        return input.Match(
            result => Ok(map(result)),
            Problem
        );
    }

    /// <summary>
    ///     Maps an ErrorOr to either an OK result or a Problem Result
    /// </summary>
    /// <param name="input">The ErrorOr object of type input</param>
    /// <typeparam name="TIn">The input type</typeparam>
    /// <returns>IActionResult of type OK or Problem</returns>
    protected IActionResult OkOrProblem<TIn>(ErrorOr<TIn> input)
    {
        return input.Match(
            result => Ok(result),
            Problem
        );
    }

    protected IActionResult CreatedAtActionOrProblem<TIn, TOut>(ErrorOr<TIn> input, string routeName,
        Func<TIn, object> routeValues)
    {
        return input.Match(
            result => CreatedAtAction(routeName, routeValues(result), Mapper.Map<TOut>(result!)),
            Problem
        );
    }
}