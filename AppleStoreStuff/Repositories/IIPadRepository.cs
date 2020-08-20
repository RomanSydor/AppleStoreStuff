using AppleStoreStuff.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppleStoreStuff.Repositories
{
    public interface IIPadRepository
    {
        Task<List<IPad>> GetIPadsAsync();
        Task<IPad> GetIPadByIdAsync(int id);
    }
}
