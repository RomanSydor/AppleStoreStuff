using System.Linq;
using AppleStoreStuff.Models;
using AppleStoreStuff.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppleStoreStuff.Controllers
{
    public class AppleWatchController : Controller
    {
        private IAppleWatchRepository _appleWatchRepository;

        public AppleWatchController(IAppleWatchRepository appleWatchRepository)
        {
            _appleWatchRepository = appleWatchRepository;
        }

        [HttpGet]
        [Route("/AppleWatch/Index")]
        public IActionResult Index()
        {
            var watches = _appleWatchRepository.GetAllWatches(x => true);
            return View(watches);
        }

        [HttpGet]
        [Route("/AppleWatch/Index/{model}")]
        public IActionResult Index([FromRoute] string model)
        {
            var watches = _appleWatchRepository.GetAllWatches(x => x.AppleWatchModel == model);
            return View(watches.ToList());
        }

        [HttpGet]
        [Route("/AppleWatch/Details/{id}")]
        public IActionResult Details([FromRoute]int id)
        {
            var watch = _appleWatchRepository.GetWatchByProp(x => x.Id == id);
            return View(watch);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/AppleWatch/Create")]
        public IActionResult Create([Bind("Id,AppleWatchModel," +
            "ScreenSize,Cellular,Gps,Color,HousingMaterial,StrapType," +
            "Price,Description,AmountOfProduct")]AppleWatch watch)
        {
            if (ModelState.IsValid)
            {
                _appleWatchRepository.CreateWatch(watch);
                return RedirectToAction("Details", "AppleWatch", new AppleWatch { Id = watch.Id });
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watch = _appleWatchRepository.GetWatchByProp(x => x.Id == id);
            if (watch == null)
            {
                return NotFound();
            }

            return View(watch);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var watch = _appleWatchRepository.GetWatchByProp(x => x.Id == id);
            _appleWatchRepository.DeleteWatch(watch);
            return RedirectToAction("Index", "AppleWatch");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watch = _appleWatchRepository.GetWatchByProp(x => x.Id == id);
            if (watch == null)
            {
                return NotFound();
            }

            return View(watch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,AppleWatchModel," +
            "ScreenSize,Cellular,Gps,Color,HousingMaterial,StrapType," +
            "Price,Description,AmountOfProduct")]AppleWatch watch)
        {
            if (id != watch.Id)
            {
                return NotFound();
            }

            var m = _appleWatchRepository.GetWatchByProp(x => x.Id == id);
            _appleWatchRepository.EditWatch(m, x =>
            {
                x.AppleWatchModel = watch.AppleWatchModel;
                x.ScreenSize = watch.ScreenSize;
                x.Cellular = watch.Cellular;
                x.Gps = watch.Gps;
                x.Color = watch.Color;
                x.HousingMaterial = watch.HousingMaterial;
                x.StrapType = watch.StrapType;
                x.Price = watch.Price;
                x.Description = watch.Description;
                x.AmountOfProduct = watch.AmountOfProduct;
            });
            return RedirectToAction("Details", "AppleWatch", new AppleWatch { Id = id });
        }

    }
}