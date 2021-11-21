using Microsoft.EntityFrameworkCore;

using TimeNowWorld.Models;

namespace TimeNowWorld.Data;

public class TimeNowWorldContext : DbContext
{
    #pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    public TimeNowWorldContext(DbContextOptions<TimeNowWorldContext> options) : base(options)
    {

    }

    public DbSet<Country> Countries { get; set; }
}

