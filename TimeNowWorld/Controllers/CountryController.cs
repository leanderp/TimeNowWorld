using Microsoft.AspNetCore.Mvc;

using TimeNowWorld.Core.Services;
using TimeNowWorld.Models;

namespace TimeNowWorld.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : Controller
{
    private readonly ICountryServices _countryServices;
    public CountryController(ICountryServices countryServices)
    {
        _countryServices = countryServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetCountries()
    {
        return Ok(await _countryServices.GetCountries());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCountry(int id)
    {
        var country = await _countryServices.GetCountry(id);

        if (country is null)
        {
            return NotFound();
        }

        return Ok(country);
    }

    [HttpGet("search/{name}")]
    public async Task<IActionResult> GetCountryByName(string name)
    {
        int nLetters = 2;

        if (name.Length <= nLetters)
        {
            return BadRequest($"Must have more than {nLetters} letters");
        }

        var country = await _countryServices.GetCountryByName(name);

        if (!country.Any())
        {
            return NotFound(country);
        }

        return Ok(country);
    }

    [HttpPost]
    public async Task<IActionResult> InsertCountry([FromBody] Country country)
    {
        if (country is null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var create = await _countryServices.InsertCountry(country);

        if (!create)
        {
            return BadRequest();
        }

        return Created(new Uri($"{Request.Path}/{country.Id}", UriKind.Relative), country);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCountry([FromBody] Country country)
    {
        if (country is null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var create = await _countryServices.UpdateCountry(country);

        if (!create)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        var result = await _countryServices.DeleteCountry(id);

        if (!result)
        {
            return BadRequest();
        }

        return NoContent();
    }
}

