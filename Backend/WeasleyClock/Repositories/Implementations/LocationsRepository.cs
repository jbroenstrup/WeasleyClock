using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeasleyClock.Model;
using WeasleyClock.Model.Data;
using WeasleyClock.Repositories.Interfaces;

namespace WeasleyClock.Repositories.Implementations
{
    public class LocationsRepository : ILocationsRepository
    {
        private const float _earthRadiusKm = 6371;
        private const float _mPerKm = 1000.0f;

        public LocationsRepository()
        {
        }

        public async Task<Location> GetCurrentLocation(string userName, double lattitude, double longitude)
        {
            using (var db = new LocationsContext())
            {
                var candidates = await db
                    .Locations
                    .Where(l => l.UserName == userName && DistanceInKmBetweenEarthCoordinates(l.Latitude, l.Longitude, lattitude, longitude) < l.MaxDistance)
                    .ToListAsync();

                return candidates.First();
            }
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        private double DistanceInKmBetweenEarthCoordinates(double lat1, double lon1, double lat2, double lon2)
        {
            var dLat = DegreesToRadians(lat2 - lat1);
            var dLon = DegreesToRadians(lon2 - lon1);

            lat1 = DegreesToRadians(lat1);
            lat2 = DegreesToRadians(lat2);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return _earthRadiusKm * c * _mPerKm;
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
