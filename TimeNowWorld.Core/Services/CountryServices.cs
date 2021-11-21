using TimeNowWorld.Data;
using TimeNowWorld.Data.Repository;
using TimeNowWorld.Models;

namespace TimeNowWorld.Core.Services;

public class CountryServices : ICountryServices
{
    private readonly ICountryRepository _countryRepository;
    public CountryServices(TimeNowWorldContext countryContext)
    {
        _countryRepository = new CountryRepository(countryContext);
    }

    public async Task<IEnumerable<Country>> GetCountries()
    {
        var countries = await _countryRepository.GetAllCountries();

        return countries;
    }

    public async Task<Country> GetCountry(int id)
    {
        var country = await _countryRepository.GetCountry(id);

        return country;
    }

    public async Task<IEnumerable<Country>> GetCountryByName(string name)
    {
        var country = await _countryRepository.GetCountryByName(name);

        if (!country.Any())
        {
            country = await _countryRepository.GetCountryByAllName(name);
        }

        return country;
    }

    public async Task<bool> InsertCountry(Country country)
    {
        var create = await _countryRepository.InsertCountry(country);

        return create;
    }

    public async Task<bool> UpdateCountry(Country country)
    {
        var update = await _countryRepository.UpdateCountry(country);

        return update;
    }

    public async Task<bool> DeleteCountry(int id)
    {
        var result = await _countryRepository.DeleteCountry(id);

        return result;
    }
}