using AppleStoreStuff.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AppleStoreStuff.Repositories
{
    public interface IProductRepository 
    {
        IEnumerable<Product> GetCart(int purchaseId);
    }

    public class ProductRepository : IProductRepository
    {
        private IPurchaseRepository _purchaseRepository;
        private Cart _cart;

        public ProductRepository(IPurchaseRepository purchaseRepository, Cart cart)
        {
            _purchaseRepository = purchaseRepository;
            _cart = cart;
        }

        public IEnumerable<Product> GetCart(int purchaseId)
        {
            var purch = _purchaseRepository.GetPurchaseByProp(x => x.Id == purchaseId);
            _cart.CartList.Add(JsonConvert.DeserializeObject<Product>(purch.BoughtProds));

            return _cart.CartList;
        }

    }
}
