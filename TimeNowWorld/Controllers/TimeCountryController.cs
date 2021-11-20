using Microsoft.AspNetCore.Mvc;

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

        return Ok(targetTime);
    }
}

public class TargetTime
{
    public Country? MyCountry { get; set; }

    public List<Country>? TargetCountries { get; set; }
}

