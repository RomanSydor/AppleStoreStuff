﻿using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {
            var macs = await _macRepository.GetMacsAsync();
            return View(macs);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var mac = await _macRepository.GetMacByIdAsync(id);

            if (mac == null)
            {
                return NotFound();
            }
            return View(mac);
        }

    }
}