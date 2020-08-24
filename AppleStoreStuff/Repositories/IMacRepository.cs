using AppleStoreStuff.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AppleStoreStuff.Repositories
{
    public interface IMacRepository
    {
        Task<List<Mac>> GetMacsAsync();
        Task<Mac> GetMacByIdAsync(int id);
        Task<List<Mac>> GetMacsByModel(string model, string color, string memory);
    }
}
