using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {
            var iPads = await _iPadRepository.GetIPadsAsync();
            return View(iPads);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var iPad = await _iPadRepository.GetIPadByIdAsync(id);
            if (iPad == null)
            {
                return NotFound();
            }
            return View(iPad);
        }
    }
}