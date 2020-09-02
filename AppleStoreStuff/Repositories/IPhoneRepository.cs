using AppleStoreStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppleStoreStuff.Repositories
{
    public interface IIPhoneRepository
    {
        IEnumerable<IPhone> GetAlliPhones(Func<IPhone, bool> getAlliPhonesFunction);
        IPhone GetPhoneByProp(Func<IPhone, bool> getIPhonebyIdFunction);
        void CreateIPhone(IPhone iPhone);
        void DeleteIPhone(IPhone iPhone);
        void EditIPhone(IPhone iPhone, Action<IPhone> action);
    }

    public class IPhoneRepository : IIPhoneRepository
    {
        private DataContext _db;

        public IPhoneRepository(DataContext dataContext)
        {
            _db = dataContext;
        }

        public IEnumerable<IPhone> GetAlliPhones(Func<IPhone, bool> getAlliPhonesFunction)
        {
            return _db.IPhones.Where(iPhone => getAlliPhonesFunction(iPhone));
        }

        public IPhone GetPhoneByProp(Func<IPhone, bool> getIPhoneByPropFunction)
        {
            return GetAlliPhones(getIPhoneByPropFunction).FirstOrDefault();
        }

        public void CreateIPhone(IPhone iPhone)
        {
            _db.IPhones.Add(iPhone);
            _db.SaveChanges();
        }

        public void DeleteIPhone(IPhone iPhone)
        {
            if (iPhone != null)
            {
                _db.IPhones.Remove(iPhone);
            }
            _db.SaveChanges();
        }

        public void EditIPhone(IPhone iPhone, Action<IPhone> editAction)
        {
            var iph = _db.IPhones.FirstOrDefault(x => x.Id == iPhone.Id);

            if (iph != null)
            {
                editAction(iph);
            }
            _db.SaveChanges();
        }
    }
}
