using AppleStoreStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppleStoreStuff.Repositories
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> GetAllPurchases(Func<Purchase, bool> getAllPurchsesFunc);
        Purchase GetPurchaseByProp(Func<Purchase, bool> getPurchseByPropFunc);
    }

    public class PurchaseRepository : IPurchaseRepository
    {
        private DataContext _db;

        public PurchaseRepository(DataContext dataContext)
        {
            _db = dataContext;
        }

        public IEnumerable<Purchase> GetAllPurchases(Func<Purchase, bool> getAllPurchsesFunc)
        {
            return _db.Purchases.Where(pur => getAllPurchsesFunc(pur));
        }

        public Purchase GetPurchaseByProp(Func<Purchase, bool> getPurchseByPropFunc)
        {
            return GetAllPurchases(getPurchseByPropFunc).FirstOrDefault();
        }

    }
}
