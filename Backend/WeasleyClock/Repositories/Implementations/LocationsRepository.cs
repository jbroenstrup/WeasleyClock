using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeasleyClock.Model;
using WeasleyClock.Model.Data;
using WeasleyClock.Repositories.Interfaces;
using WeasleyClock.Utilities;

namespace WeasleyClock.Repositories.Implementations
{
    public class LocationsRepository : ILocationsRepository
    {
        public LocationsRepository()
        {
        }

        public async Task<Location> GetCurrentLocation(string userName, double latitude, double longitude)
        {
            using (var db = new LocationsContext())
            {
                var candidates = await db
                    .Locations
                    .Where(l => l.UserName == userName && 
                           DistanceCalculator.DistanceInKmBetweenEarthCoordinates(l.Latitude, l.Longitude, latitude, longitude) < l.MaxDistance)
                    .ToListAsync();

                if (candidates.Any())
                    return candidates.First();
                else
                    return new Location { UserName = userName, Latitude = latitude, Longitude = longitude, LocationName = "Unknown" };
            }
        }


        public async Task RemoveLocation(Guid id)
        {
            using (var db = new LocationsContext())
            {
                var entity = await db.Locations.FindAsync(id);
                db.Locations.Remove(entity);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<Location>> GetAll()
        {
            using (var db = new LocationsContext())
            {
                return await db.Locations.ToListAsync();
            }
        }

        public async Task AddLocation(Location location)
        {
            using (var db = new LocationsContext())
            {
                db.Locations.Add(location);
                await db.SaveChangesAsync();
            }
        }
    }
}
