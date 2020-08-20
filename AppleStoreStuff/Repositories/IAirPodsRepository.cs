using AppleStoreStuff.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppleStoreStuff.Repositories
{
    public interface IAirPodsRepository
    {
        Task<List<AirPods>> GetAirPodsesAsync();
        Task<AirPods> GetAirPodsByIdAsync(int id);
    }
}
