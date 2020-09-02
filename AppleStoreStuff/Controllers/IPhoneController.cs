using System.Linq;
using AppleStoreStuff.Models;
using AppleStoreStuff.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppleStoreStuff.Controllers
{
    public class IPhoneController : Controller
    {
        private IIPhoneRepository _iPhoneRepository;

        public IPhoneController(IIPhoneRepository iPhoneRepository)
        {
            _iPhoneRepository = iPhoneRepository;
        }

        [HttpGet]
        [Route("/IPhone/Index")]
        public IActionResult Index()
        {
            var iPhones = _iPhoneRepository.GetAlliPhones(x => true); //TODO method overloading, maybe =)
            return View(iPhones.ToList());
        }

        [HttpGet]
        [Route("/IPhone/Index/{model}")]
        public IActionResult Index([FromRoute] string model)
        {
            var iPhones = _iPhoneRepository.GetAlliPhones(x => x.IPhoneModel == model);
            return View(iPhones.ToList());
        }

        [HttpGet]
        [Route("/IPhone/Details/{id}")]
        public IActionResult Details([FromRoute]int id)
        {
            var iPhone = _iPhoneRepository.GetPhoneByProp(x => x.Id == id);
            return View(iPhone);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/IPhone/Create")]
        public IActionResult Create([Bind("Id,IPhoneModel,Memory,Weight," +
            "ScreenType,ScreenSize,UhdRecording,BatteryCapacity,Processor," +
            "Ram,MainCamera,FrontCamera,Color," +
            "Price,Description,AmountOfProduct")]IPhone iPhone) 
        {
            if (ModelState.IsValid)
            {
                _iPhoneRepository.CreateIPhone(iPhone);
                return RedirectToAction("Details", "IPhone", new IPhone { Id = iPhone.Id});
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iph = _iPhoneRepository.GetPhoneByProp(x => x.Id == id);
            if (iph == null)
            {
                return NotFound();
            }

            return View(iph);
        }

        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var iPhone = _iPhoneRepository.GetPhoneByProp(x => x.Id == id);
            _iPhoneRepository.DeleteIPhone(iPhone);
            return RedirectToAction("Index", "IPhone");
        }

        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iph = _iPhoneRepository.GetPhoneByProp(x => x.Id == id);
            if (iph == null)
            {
                return NotFound();
            }

            return View(iph);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,IPhoneModel,Memory,Weight," +
            "ScreenType,ScreenSize,UhdRecording,BatteryCapacity,Processor," +
            "Ram,MainCamera,FrontCamera,Color," +
            "Price,Description,AmountOfProduct")]IPhone iPhone)
        {
            if (id != iPhone.Id)
            {
                return NotFound();
            }

            var iph = _iPhoneRepository.GetPhoneByProp(x => x.Id == id);
            _iPhoneRepository.EditIPhone(iph, x =>
            {
                x.IPhoneModel = iPhone.IPhoneModel;
                x.Memory = iPhone.Memory;
                x.Weight = iPhone.Weight;
                x.ScreenType = iPhone.ScreenType;
                x.ScreenSize = iPhone.ScreenSize;
                x.UhdRecording = iPhone.UhdRecording;
                x.BatteryCapacity = iPhone.BatteryCapacity;
                x.Processor = iPhone.Processor;
                x.Ram = iPhone.Ram;
                x.MainCamera = iPhone.MainCamera;
                x.FrontCamera = iPhone.FrontCamera;
                x.Color = iPhone.Color;
                x.Price = iPhone.Price;
                x.Description = iPhone.Description;
                x.AmountOfProduct = iPhone.AmountOfProduct;
            });
            return RedirectToAction("Details", "IPhone", new IPhone { Id = id });
        }
    }
}