using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimeNowWorld.Models;

namespace TimeNowWorld.Data
{
    public class TimeNowWorldContext : DbContext
    {
        public TimeNowWorldContext(DbContextOptions<TimeNowWorldContext> options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
    }
}
