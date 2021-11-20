using Microsoft.EntityFrameworkCore;

using TimeNowWorld.Models;

namespace TimeNowWorld.Data;

public class TimeNowWorldContext : DbContext
{
    public TimeNowWorldContext(DbContextOptions<TimeNowWorldContext> options) : base(options)
    {

    }

    public DbSet<Country> Countries { get; set; }
}

