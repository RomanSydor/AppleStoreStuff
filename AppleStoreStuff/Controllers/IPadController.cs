using System.Linq;
using AppleStoreStuff.Models;
using AppleStoreStuff.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppleStoreStuff.Controllers
{
    public class IPadController : Controller
    {
        private IIPadRepository _iPadRepository;

        public IPadController(IIPadRepository iPadRepository)
        {
            _iPadRepository = iPadRepository;
        }

        [HttpGet]
        [Route("/IPad/Index")]
        public IActionResult Index()
        {
            var iPads = _iPadRepository.GetAlliPads(x => true);
            return View(iPads.ToList());
        }

        [HttpGet]
        [Route("/IPad/Index/{model}")]
        public IActionResult Index([FromRoute] string model)
        {
            var iPads = _iPadRepository.GetAlliPads(x => x.IPadModel == model);
            return View(iPads.ToList());
        }

        [HttpGet]
        [Route("/IPad/Details/{id}")]
        public IActionResult Details([FromRoute] int id) 
        {
            var iPad = _iPadRepository.GetIPadByProp(x => x.Id == id);
            return View(iPad);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/IPad/Create")]
        public IActionResult Create([Bind("Id,IPadModel,TypeOfModel,Memory,Type," +
            "ScreenType,ScreenSize,Processor," +
            "Ram,MainCamera,FrontCamera,YearOfProduction,Color," +
            "Price,Description,AmountOfProduct")]IPad iPad)
        {
            if (ModelState.IsValid)
            {
                _iPadRepository.CreateIPad(iPad);
                return RedirectToAction("Details", "IPad", new IPad { Id = iPad.Id });
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ipd = _iPadRepository.GetIPadByProp(x => x.Id == id);
            if (ipd == null)
            {
                return NotFound();
            }

            return View(ipd);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var iPad = _iPadRepository.GetIPadByProp(x => x.Id == id);
            _iPadRepository.DeleteIPad(iPad);
            return RedirectToAction("Index", "IPad");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ipd = _iPadRepository.GetIPadByProp(x => x.Id == id);
            if (ipd == null)
            {
                return NotFound();
            }

            return View(ipd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,IPadModel,TypeOfModel,Memory,Type," +
            "ScreenType,ScreenSize,Processor," +
            "Ram,MainCamera,FrontCamera,YearOfProduction,Color," +
            "Price,Description,AmountOfProduct")]IPad iPad)
        {
            if (id != iPad.Id)
            {
                return NotFound();
            }

            var ipd = _iPadRepository.GetIPadByProp(x => x.Id == id);
            _iPadRepository.EditIPad(ipd, x =>
            {
                x.IPadModel = iPad.IPadModel;
                x.TypeOfModel = iPad.TypeOfModel;
                x.Memory = iPad.Memory;
                x.Type = iPad.Type;
                x.ScreenType = iPad.ScreenType;
                x.ScreenSize = iPad.ScreenSize;
                x.Processor = iPad.Processor;
                x.Ram = iPad.Ram;
                x.MainCamera = iPad.MainCamera;
                x.FrontCamera = iPad.FrontCamera;
                x.YearOfProduction = iPad.YearOfProduction;
                x.Color = iPad.Color;
                x.Price = iPad.Price;
                x.Description = iPad.Description;
                x.AmountOfProduct = iPad.AmountOfProduct;
            });
            return RedirectToAction("Details", "IPad", new IPad { Id = id });
        }
    }
}