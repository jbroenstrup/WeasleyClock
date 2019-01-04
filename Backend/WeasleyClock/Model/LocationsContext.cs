using Microsoft.EntityFrameworkCore;
using WeasleyClock.Model.Data;

namespace WeasleyClock.Model
{
    public class LocationsContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=locations.db");
        }
    }
}
