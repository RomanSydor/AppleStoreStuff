using AppleStoreStuff.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppleStoreStuff.Repositories
{
    public interface IAppleWatchRepository
    {
        Task<List<AppleWatch>> GetAppleWatchesAsync();
        Task<AppleWatch> GetAppleWatchByIdAsync(int id);
    }
}
