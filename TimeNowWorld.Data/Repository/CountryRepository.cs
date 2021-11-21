
using Microsoft.EntityFrameworkCore;

using TimeNowWorld.Models;

namespace TimeNowWorld.Data.Repository;

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

    public async Task<Country?> GetCountry(int id)
    {
        return await _context.Countries.FirstOrDefaultAsync(c => c.IdCountry == id && c.Default == true);
    }

    public async Task<IEnumerable<Country?>> GetCountryByName(string name)
    {
        return await _context.Countries.Where(c => c.NameES.ToLower().StartsWith((string)name.ToLower()) && c.Default == true).ToListAsync();
    }

    public async Task<IEnumerable<Country?>> GetCountryByAllName(string name)
    {
        return await _context.Countries.Where(c => c.NameES.ToLower().Contains((string)name.ToLower()) && c.Default == true).ToListAsync();
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

    public async Task<bool> InsertListCountry(List<Country> country)
    {
        if (country is null)
        {
            throw new ArgumentNullException(nameof(country));
        }

        await _context.Countries.AddRangeAsync(country);
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

