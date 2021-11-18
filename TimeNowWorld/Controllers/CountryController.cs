using Microsoft.AspNetCore.Mvc;

using TimeNowWorld.Data;
using TimeNowWorld.Data.Repository;
using TimeNowWorld.Models;

namespace TimeNowWorld.Controllers
{

    // https://www.c-sharpcorner.com/blogs/get-any-date-and-time-as-per-time-zone-in-c-sharp

    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(TimeNowWorldContext countryContext)
        {
            _countryRepository = new CountryRepository(countryContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            return Ok(await _countryRepository.GetAllCountries());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var country = await _countryRepository.GetCountryById(id);

            if (country is null)
            {
                return NotFound();
            }
            
            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCountry([FromBody]Country country)
        {
            if (country is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var create = await _countryRepository.InsertCountry(country);

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

            var create = await _countryRepository.UpdateCountry(country);

            if (!create)
            {
                return BadRequest();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var result = await _countryRepository.DeleteCountry(id);

            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
