using AppleStoreStuff.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppleStoreStuff.Repositories
{
    public class AirPodsRepository : IAirPodsRepository
    {

        private DataContext _dataContext;

        public AirPodsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<AirPods> GetAirPodsByIdAsync(int id)
        {
            return await _dataContext.AirPodses.SingleOrDefaultAsync(p => p.Id == id);

        }

        public async Task<List<AirPods>> GetAirPodsesAsync()
        {
            return await _dataContext.AirPodses.ToListAsync();
        }
    }
}
