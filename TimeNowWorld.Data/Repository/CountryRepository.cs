
using Microsoft.EntityFrameworkCore;

using TimeNowWorld.Models;

namespace TimeNowWorld.Data.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly TimeNowWorldContext _context;

        public CountryRepository(TimeNowWorldContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteCountry(int id)
        {
            int result = 0;

            if (CountryExist(id))
            {
                _context.Countries.Remove(new Country() { Id = id });
                result = await _context.SaveChangesAsync();
            }

            return result > 0;
        }

        public async Task<IEnumerable<Country?>> GetAllCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country?> GetCountryById(int id)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> InsertCountry(Country country)
        {
            if (country is null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            await _context.Countries.AddAsync(country);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public async Task<bool> UpdateCountry(Country country)
        {
            if (country is null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            _context.Entry(country).State = EntityState.Modified;

            int result;

            try
            {
                result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!CountryExist(country.Id))
            {
                result = 0;
            }

            return result > 0;
        }

        private bool CountryExist(long id) =>
            _context.Countries.Any(c => c.Id == id);
    }
}
