using BuberDinner.Api.Common;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Dinners;

[Route("[controller]")]
public class DinnersController : ApiControllerBase
{
    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}