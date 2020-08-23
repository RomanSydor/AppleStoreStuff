using AppleStoreStuff.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppleStoreStuff.Repositories
{
    public interface IIPhoneRepository
    {
        Task<List<IPhone>> GetIPhonesAsync();
        Task<IPhone> GetIPhoneByIdAsync(int id);
        Task<List<IPhone>> GetIPhonesByModel(string model, string memory); 
    }
}
