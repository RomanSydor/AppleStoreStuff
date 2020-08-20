using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {
            var watches = await _appleWatchRepository.GetAppleWatchesAsync();
            return View(watches);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var watch = await _appleWatchRepository.GetAppleWatchByIdAsync(id);
            return View(watch);
        }

    }
}