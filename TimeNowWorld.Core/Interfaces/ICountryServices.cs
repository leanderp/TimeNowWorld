using TimeNowWorld.Models;

namespace TimeNowWorld.Core.Services;

public interface ICountryServices
{
    Task<IEnumerable<Country?>?> GetCountries();
    Task<Country?> GetCountry(int id);
    Task<IEnumerable<Country?>> GetCountryByName(string name);
    Task<bool> InsertCountry(Country country);
    Task<bool> UpdateCountry(Country country);
    Task<bool> DeleteCountry(int id);
}
