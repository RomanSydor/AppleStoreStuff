using AppleStoreStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppleStoreStuff.Repositories
{
    public interface IAppleWatchRepository
    {
        IEnumerable<AppleWatch> GetAllWatches(Func<AppleWatch, bool> getAlliWatchesFunction);
        AppleWatch GetWatchByProp(Func<AppleWatch, bool> getWatchByPropFunction);
        void CreateWatch(AppleWatch appleWatch);
        void DeleteWatch(AppleWatch appleWatch);
        void EditWatch(AppleWatch appleWatch, Action<AppleWatch> editAction);
    }

    public class AppleWatchRepository : IAppleWatchRepository
    {
        private DataContext _db;

        public AppleWatchRepository(DataContext dataContext)
        {
            _db = dataContext;
        }

        public IEnumerable<AppleWatch> GetAllWatches(Func<AppleWatch, bool> getAlliWatchesFunction)
        {
            return _db.AppleWatches.Where(appleWatch => getAlliWatchesFunction(appleWatch));
        }

        public AppleWatch GetWatchByProp(Func<AppleWatch, bool> getWatchByPropFunction)
        {
            return GetAllWatches(getWatchByPropFunction).FirstOrDefault();
        }

        public void CreateWatch(AppleWatch appleWatch)
        {
            _db.AppleWatches.Add(appleWatch);
            _db.SaveChanges();
        }

        public void DeleteWatch(AppleWatch appleWatch)
        {
            if (appleWatch != null)
            {
                _db.AppleWatches.Remove(appleWatch);
            }
            _db.SaveChanges();
        }

        public void EditWatch(AppleWatch appleWatch, Action<AppleWatch> editAction)
        {
            var aw = GetWatchByProp(x => x.Id == appleWatch.Id);
            if (aw != null)
            {
                editAction(aw);
            }
            _db.SaveChanges();
        }
    }
}
