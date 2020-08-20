using AppleStoreStuff.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
    }
}
