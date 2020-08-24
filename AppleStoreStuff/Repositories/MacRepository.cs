using AppleStoreStuff.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Mac>> GetMacsByModel(string model, string color, string memory)
        {
            var macs = _dataContext.Macs
                .Where(x => x.MacModel == model 
                && x.Color == color 
                && x.Memory == memory);

            return await macs.ToListAsync();
        }
    }
}
