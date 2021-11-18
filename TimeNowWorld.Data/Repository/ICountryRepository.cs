using TimeNowWorld.Models;

namespace TimeNowWorld.Data.Repository
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country?>> GetAllCountries();
        Task<Country?> GetCountryById(int id);
        Task<bool> InsertCountry(Country country);
        Task<bool> UpdateCountry(Country country);
        Task<bool> DeleteCountry(int id);
    }
}
