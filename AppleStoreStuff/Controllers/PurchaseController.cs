using AppleStoreStuff.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppleStoreStuff.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository _purchaseRepository;

        public PurchaseController(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        [HttpGet]
        [Route("/Purchase/Index")]
        public IActionResult Index()
        {
            var pur = _purchaseRepository.GetAllPurchases(x => true);
            return View(pur);
        }

        [HttpGet]
        [Route("/Purchase/Details/{id}")]
        public IActionResult Details([FromRoute]int id) 
        {
            var pur = _purchaseRepository.GetPurchaseByProp(x => x.Id == id);
            return View(pur);
        }
    }
}