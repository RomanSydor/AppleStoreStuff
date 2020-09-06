using System.Collections.Generic;

namespace AppleStoreStuff.Models
{
    public class Cart
    {
        public ICollection<Product> CartList = new List<Product>();
    }
}
