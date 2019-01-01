using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeasleyClock.Model.Data;

namespace WeasleyClock.Repositories
{
    public class LocationsRepository
    {
        public LocationsRepository()
        {
        }

        public Location GetCurrentLocation(string userName, double longitude, double lattitude)
        {
            return new Location();
        }
    }
}
