using AppleStoreStuff.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppleStoreStuff.Repositories
{
    public class MacRepository : IMacRepository
    {
        private readonly DataContext _dataContext;

        public MacRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Mac>> GetMacsAsync()
        {
            return await _dataContext.Macs.ToListAsync();
        }
        public async Task<Mac> GetMacByIdAsync(int id)
        {
            return await _dataContext.Macs.SingleOrDefaultAsync(m => m.Id == id);
        }

    }
}
