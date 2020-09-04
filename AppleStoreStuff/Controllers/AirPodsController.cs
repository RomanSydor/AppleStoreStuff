using System.Linq;
using AppleStoreStuff.Models;
using AppleStoreStuff.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppleStoreStuff.Controllers
{
    public class AirPodsController : Controller
    {

        private IAirPodsRepository _airPodsRepository;

        public AirPodsController(IAirPodsRepository airPodsRepository)
        {
            _airPodsRepository = airPodsRepository;
        }

        [HttpGet]
        [Route("/AirPods/Index")]
        public IActionResult Index()
        {
            var pods = _airPodsRepository.GetAllAirPods(x => true);
            return View(pods);
        }

        [HttpGet]
        [Route("/AirPods/Index/{model}")]
        public IActionResult Index([FromRoute] string model)
        {
            var pods = _airPodsRepository.GetAllAirPods(x => x.AirPodsModel == model);
            return View(pods.ToList());
        }

        [HttpGet]
        [Route("/AirPods/Details/{id}")]
        public IActionResult Details([FromRoute]int id)
        {
            var pods = _airPodsRepository.GetAirPodsByProp(x => x.Id == id);
            return View(pods);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/AirPods/Create")]
        public IActionResult Create([Bind("Id,AirPodsModel," +
            "WirelessCharging,YearOfProduction," +
            "Price,Description,AmountOfProduct")]AirPods pods)
        {
            if (ModelState.IsValid)
            {
                _airPodsRepository.CreateAirPods(pods);
                return RedirectToAction("Details", "AirPods", new AirPods { Id = pods.Id });
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pods = _airPodsRepository.GetAirPodsByProp(x => x.Id == id);
            if (pods == null)
            {
                return NotFound();
            }

            return View(pods);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var pods = _airPodsRepository.GetAirPodsByProp(x => x.Id == id);
            _airPodsRepository.DeleteAirPods(pods);
            return RedirectToAction("Index", "AirPods");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pods = _airPodsRepository.GetAirPodsByProp(x => x.Id == id);
            if (pods == null)
            {
                return NotFound();
            }

            return View(pods);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,AirPodsModel," +
            "WirelessCharging,YearOfProduction," +
            "Price,Description,AmountOfProduct")]AirPods pods)
        {
            if (id != pods.Id)
            {
                return NotFound();
            }

            var m = _airPodsRepository.GetAirPodsByProp(x => x.Id == id);
            _airPodsRepository.EditAirPods(m, x =>
            {
                x.AirPodsModel = pods.AirPodsModel;
                x.WirelessCharging = pods.WirelessCharging;
                x.YearOfProduction = pods.YearOfProduction;
                x.Price = pods.Price;
                x.Description = pods.Description;
                x.AmountOfProduct = pods.AmountOfProduct;
            });
            return RedirectToAction("Details", "AirPods", new AirPods { Id = id });
        }

    }
}