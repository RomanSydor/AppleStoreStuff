using System.Linq;
using AppleStoreStuff.Models;
using AppleStoreStuff.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppleStoreStuff.Controllers
{
    public class MacController : Controller
    {
        private IMacRepository _macRepository;

        public MacController(IMacRepository macRepository)
        {
            _macRepository = macRepository;
        }

        [HttpGet]
        [Route("/Mac/Index")]
        public IActionResult Index()
        {
            var macs = _macRepository.GetAllMacs(x => true);
            return View(macs.ToList());
        }

        [HttpGet]
        [Route("/Mac/Index/{model}")]
        public IActionResult Index([FromRoute] string model)
        {
            var macs = _macRepository.GetAllMacs(x => x.MacModel == model);
            return View(macs.ToList());
        }

        [HttpGet]
        [Route("/Mac/Details/{id}")]
        public IActionResult Details([FromRoute]int id)
        {
            var mac = _macRepository.GetMacByProp(x => x.Id == id);
            return View(mac);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/Mac/Create")]
        public IActionResult Create([Bind("Id,MacModel,Type,Memory," +
            "ScreenSize,Processor,KernelsAmount," +
            "Ram,SsdCapacity,DriveCapacity,VideoCard,YearOfProduction,Color," +
            "Price,Description,AmountOfProduct")]Mac mac)
        {
            if (ModelState.IsValid)
            {
                _macRepository.CreateMac(mac);
                return RedirectToAction("Details", "Mac", new Mac { Id = mac.Id });
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mac = _macRepository.GetMacByProp(x => x.Id == id);
            if (mac == null)
            {
                return NotFound();
            }

            return View(mac);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var mac = _macRepository.GetMacByProp(x => x.Id == id);
            _macRepository.DeleteMac(mac);
            return RedirectToAction("Index", "Mac");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mac = _macRepository.GetMacByProp(x => x.Id == id);
            if (mac == null)
            {
                return NotFound();
            }

            return View(mac);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,MacModel,Type,Memory," +
            "ScreenSize,Processor,KernelsAmount," +
            "Ram,SsdCapacity,DriveCapacity,VideoCard,YearOfProduction,Color," +
            "Price,Description,AmountOfProduct")]Mac mac)
        {
            if (id != mac.Id)
            {
                return NotFound();
            }

            var m = _macRepository.GetMacByProp(x => x.Id == id);
            _macRepository.EditMac(m, x =>
            {
                x.MacModel = mac.MacModel;
                x.Type = mac.Type;
                x.Memory = mac.Memory;
                x.ScreenSize = mac.ScreenSize;
                x.Processor = mac.Processor;
                x.KernelsAmount = mac.KernelsAmount;
                x.Ram = mac.Ram;
                x.SsdCapacity = mac.SsdCapacity;
                x.DriveCapacity = mac.DriveCapacity;
                x.VideoCard = mac.VideoCard;
                x.YearOfProduction = mac.YearOfProduction;
                x.Color = mac.Color;
                x.Price = mac.Price;
                x.Description = mac.Description;
                x.AmountOfProduct = mac.AmountOfProduct;
            });
            return RedirectToAction("Details", "Mac", new Mac { Id = id });
        }
    }
}