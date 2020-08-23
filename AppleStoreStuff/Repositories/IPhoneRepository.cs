using AppleStoreStuff.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleStoreStuff.Repositories
{
    public class IPhoneRepository : IIPhoneRepository
    {
        private readonly DataContext _dataContext;

        public IPhoneRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<IPhone>> GetIPhonesAsync()
        {
            return await _dataContext.IPhones.ToListAsync();
        }

        public async Task<IPhone> GetIPhoneByIdAsync(int id)
        {
            return await _dataContext.IPhones.SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<IPhone>> GetIPhonesByModel(string model, string memory) 
        {
            var iPhones = _dataContext
                .IPhones.Where(i => i.Memory == memory && i.IPhoneModel == model);

            return await iPhones
                .OrderBy(m => m.Memory)
                .OrderBy(p => p.Price)
                .ToListAsync();
        }
    }
}
