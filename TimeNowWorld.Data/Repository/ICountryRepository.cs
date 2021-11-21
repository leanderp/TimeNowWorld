using TimeNowWorld.Models;

namespace TimeNowWorld.Data.Repository;

public interface ICountryRepository
{
    Task<IEnumerable<Country?>> GetAllCountries();
    Task<Country?> GetCountry(int id);
    Task<IEnumerable<Country?>> GetCountryByName(string name);
    Task<IEnumerable<Country?>> GetCountryByAllName(string name);
    Task<bool> InsertCountry(Country country);
    Task<bool> InsertListCountry(List<Country> country);
    Task<bool> UpdateCountry(Country country);
    Task<bool> DeleteCountry(int id);
}

