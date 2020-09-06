using AppleStoreStuff.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AppleStoreStuff.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("/Product/Index/{purchId}")]
        public IActionResult Index([FromRoute] int purchId)
        {
            return View(_productRepository.GetCart(purchId).ToList());
        }
    }
}