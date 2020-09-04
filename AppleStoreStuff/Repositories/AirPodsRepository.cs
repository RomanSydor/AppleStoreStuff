using AppleStoreStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppleStoreStuff.Repositories
{

    public interface IAirPodsRepository 
    {
        IEnumerable<AirPods> GetAllAirPods(Func<AirPods, bool> getAllAirPodsFunction);
        AirPods GetAirPodsByProp(Func<AirPods, bool> getAirPodsByPropFunction);
        void CreateAirPods(AirPods airPods);
        void DeleteAirPods(AirPods airPods);
        void EditAirPods(AirPods airPods, Action<AirPods> editAction);
    }

    public class AirPodsRepository : IAirPodsRepository
    {

        private DataContext _db;

        public AirPodsRepository(DataContext dataContext)
        {
            _db = dataContext;
        }

        public IEnumerable<AirPods> GetAllAirPods(Func<AirPods, bool> getAllAirPodsFunction)
        {
            return _db.AirPodses.Where(pods => getAllAirPodsFunction(pods));
        }

        public AirPods GetAirPodsByProp(Func<AirPods, bool> getAirPodsByPropFunction)
        {
            return GetAllAirPods(getAirPodsByPropFunction).FirstOrDefault();
        }

        public void CreateAirPods(AirPods airPods)
        {
            _db.AirPodses.Add(airPods);
            _db.SaveChanges();
        }

        public void DeleteAirPods(AirPods airPods)
        {
            if (airPods != null)
            {
                _db.AirPodses.Remove(airPods);
            }
            _db.SaveChanges();
        }

        public void EditAirPods(AirPods airPods, Action<AirPods> editAction)
        {
            var airP = GetAirPodsByProp(x => x.Id == airPods.Id);
            if (airP != null)
            {
                editAction(airP);
            }
            _db.SaveChanges();
        }
    }
}
