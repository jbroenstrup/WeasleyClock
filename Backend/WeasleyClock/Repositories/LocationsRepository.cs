using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeasleyClock.Model;
using WeasleyClock.Model.Data;

namespace WeasleyClock.Repositories
{
    public class LocationsRepository
    {
        public LocationsRepository()
        {
        }

        public async Task<Location> GetCurrentLocation(string userName, double lattitude, double longitude)
        {
            using (var db = new LocationsContext())
            {
                var candidates = await db
                    .Locations
                    .Where(l => l.UserName == userName && CalculateDistance(l, lattitude, longitude) < l.MaxDistance)
                    .ToListAsync();

                return candidates.First();
            }
        }

        private double CalculateDistance(Location location, double lattitude, double longitude)
        {
            return Math.Sqrt((Math.Pow(location.Latitude - lattitude, 2)) + (Math.Pow(location.Longitude - longitude, 2)));
        }

        internal async Task RemoveLocation(Guid id)
        {
            using (var db = new LocationsContext())
            {
                var entity = await db.Locations.FindAsync(id);
                db.Locations.Remove(entity);
                await db.SaveChangesAsync();
            }
        }

        internal async Task<List<Location>> GetAll()
        {
            using (var db = new LocationsContext())
            {
                return await db.Locations.ToListAsync();
            }
        }

        internal async Task AddLocation(Location location)
        {
            using (var db = new LocationsContext())
            {
                db.Locations.Add(location);
                await db.SaveChangesAsync();
            }
        }
    }
}
