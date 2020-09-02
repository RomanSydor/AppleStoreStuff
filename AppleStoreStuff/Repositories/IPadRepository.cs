using AppleStoreStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppleStoreStuff.Repositories
{

    public interface IIPadRepository 
    {
        IEnumerable<IPad> GetAlliPads(Func<IPad, bool> getAlliPadsFunction);
        IPad GetIPadByProp(Func<IPad, bool> getIPadbyIdFunction);
        void CreateIPad(IPad iPad);
        void DeleteIPad(IPad iPad);
        void EditIPad(IPad iPad, Action<IPad> editAction);
    }

    public class IPadRepository : IIPadRepository
    {
        private DataContext _db;

        public IPadRepository(DataContext dataContext)
        {
            _db = dataContext;
        }

        public IEnumerable<IPad> GetAlliPads(Func<IPad, bool> getAlliPadsFunction)
        {
            return _db.IPads.Where(iPad => getAlliPadsFunction(iPad));
        }

        public IPad GetIPadByProp(Func<IPad, bool> getIPadbyIdFunction)
        {
            return GetAlliPads(getIPadbyIdFunction).FirstOrDefault();
        }

        public void CreateIPad(IPad iPad)
        {
            _db.IPads.Add(iPad);
            _db.SaveChanges();
        }

        public void DeleteIPad(IPad iPad)
        {
            if (iPad != null)
            {
                _db.Remove(iPad);
            }
            _db.SaveChanges();
        }

        public void EditIPad(IPad iPad, Action<IPad> editAction)
        {
            var ipd = GetIPadByProp(x => x.Id == iPad.Id);

            if (ipd != null) 
            {
                editAction(ipd);
            }
            _db.SaveChanges();
        }
    }
}
