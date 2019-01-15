using System;

namespace WeasleyClock.Utilities
{
    public class DistanceCalculator
    {
        private const float _earthRadiusKm = 6371;
        private const float _mPerKm = 1000.0f;

        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        public static double DistanceInKmBetweenEarthCoordinates(double lat1, double lon1, double lat2, double lon2)
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
    }
}
