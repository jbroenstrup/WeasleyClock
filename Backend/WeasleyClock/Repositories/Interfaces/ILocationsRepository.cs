using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeasleyClock.Model.Data;

namespace WeasleyClock.Repositories.Interfaces
{
    public interface ILocationsRepository
    {
        Task<Location> GetCurrentLocation(string userName, double lattitude, double longitude);
        Task RemoveLocation(Guid id);
        Task<List<Location>> GetAll();
        Task AddLocation(Location location);
    }
}