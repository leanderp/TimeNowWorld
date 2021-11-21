using Microsoft.AspNetCore.Mvc;

using TimeNowWorld.Core.Services;
using TimeNowWorld.Models;

namespace TimeNowWorld.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeCountryController : Controller
{
    [HttpPost]
    public IActionResult GetTimeCountry([FromBody] TargetTime targetTime)
    {
        if (targetTime is null)
        {
            BadRequest();
        }

        var targetEvent = TimeCountryServices.GetTimeCountry(targetTime);

        return Ok(targetEvent);
    }
}

