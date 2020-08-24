using AppleStoreStuff.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleStoreStuff.Repositories
{
    public class IPadRepository : IIPadRepository
    {

        private readonly DataContext _dataContext;

        public IPadRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IPad> GetIPadByIdAsync(int id)
        {
            return await _dataContext.IPads.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<IPad>> GetIPadsAsync()
        {
            return await _dataContext.IPads.ToListAsync();
        }

        public async Task<List<IPad>> GetIPadsByModel(string model, string memory, string type)
        {
            var iPads = _dataContext.IPads
                .Where(i => i.IPadModel == model 
                && i.Memory == memory 
                && i.Type == type);
            return await iPads.ToListAsync();
        }
    }
}
