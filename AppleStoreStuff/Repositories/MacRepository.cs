using AppleStoreStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppleStoreStuff.Repositories
{
    public interface IMacRepository 
    {
        IEnumerable<Mac> GetAllMacs(Func<Mac, bool> getAlliMacsFunction);
        Mac GetMacByProp(Func<Mac, bool> getMacByPropFunction);
        void CreateMac(Mac mac);
        void DeleteMac(Mac mac);
        void EditMac(Mac mac, Action<Mac> editAction);
    }

    public class MacRepository : IMacRepository
    {
        private DataContext _db;

        public MacRepository(DataContext db)
        {
            _db = db;
        }

        public IEnumerable<Mac> GetAllMacs(Func<Mac, bool> getAlliMacsFunction)
        {
            return _db.Macs.Where(mac => getAlliMacsFunction(mac));
        }

        public Mac GetMacByProp(Func<Mac, bool> getMacByPropFunction)
        {
            return GetAllMacs(getMacByPropFunction).FirstOrDefault();
        }

        public void CreateMac(Mac mac)
        {
            _db.Macs.Add(mac);
            _db.SaveChanges();
        }

        public void DeleteMac(Mac mac)
        {
            if (mac != null)
            {
                _db.Macs.Remove(mac);
            }
            _db.SaveChanges();
        }

        public void EditMac(Mac mac, Action<Mac> editAction)
        {
            var m = GetMacByProp(x => x.Id == mac.Id);
            if (m != null)
            {
                editAction(m);
            }
            _db.SaveChanges();
        }
    }
}
