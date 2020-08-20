using AppleStoreStuff.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
    }
}
