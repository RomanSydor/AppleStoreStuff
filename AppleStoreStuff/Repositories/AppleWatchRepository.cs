using AppleStoreStuff.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppleStoreStuff.Repositories
{
    public class AppleWatchRepository : IAppleWatchRepository
    {
        private DataContext _dataContext;

        public AppleWatchRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<AppleWatch> GetAppleWatchByIdAsync(int id)
        {
            return await _dataContext.AppleWatches.SingleOrDefaultAsync(w => w.Id == id);
        }

        public async Task<List<AppleWatch>> GetAppleWatchesAsync()
        {
            return await _dataContext.AppleWatches.ToListAsync();
        }

    }
}
