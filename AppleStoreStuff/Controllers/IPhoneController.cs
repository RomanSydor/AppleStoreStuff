using AppleStoreStuff.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            var iPhones = await _iPhoneRepository.GetIPhonesAsync();
            return View(iPhones);
        }

        [HttpGet]
        [Route("/IPhone/Details/{id}")]
        public async Task<IActionResult> Details([FromRoute]int id)
        {
            var iPhone = await _iPhoneRepository.GetIPhoneByIdAsync(id);

            if (iPhone == null)
            {
                return NotFound();
            }

            return View(iPhone);
        }
    }
}