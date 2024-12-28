using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{  
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult EklePersonel([FromBody] Personel yeniPersonel)
        {
            _context.Personel.Add(yeniPersonel);
            _context.SaveChanges();
            return Json(yeniPersonel);
        }

        [HttpPost]
        public IActionResult SilPersonel(int id)
        {
            var personel = _context.Personel.FirstOrDefault(p => p.PersonelID == id);
            if (personel == null)
                return BadRequest("Personel bulunamadı.");
            _context.Personel.Remove(personel);
            _context.SaveChanges();
            return Json(personel);
        }

        [HttpPost]
        public IActionResult EkleHizmet([FromBody] Hizmet yeniHizmet)
        {
            _context.Hizmet.Add(yeniHizmet);
            _context.SaveChanges();
            return Json(yeniHizmet);
        }

        [HttpPost]
        public IActionResult SilHizmet(int id)
        {
            var hizmet = _context.Hizmet.FirstOrDefault(h => h.HizmetID == id);
            if (hizmet == null)
                return BadRequest("Hizmet bulunamadı.");
            _context.Hizmet.Remove(hizmet);
            _context.SaveChanges();
            return Json(hizmet);
        }

        [HttpGet]
        public IActionResult GetPersoneller()
        {
            var personeller = _context.Personel.ToList();
            return Json(personeller);
        }

        [HttpGet]
        public IActionResult GetHizmetler()
        {
            var hizmetler = _context.Hizmet.ToList();
            return Json(hizmetler);
        }
    }
   
}
