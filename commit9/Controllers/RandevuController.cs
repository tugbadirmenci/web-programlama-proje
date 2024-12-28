using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class RandevuController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor: ApplicationDbContext bağlanıyor
        public RandevuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RandevuAl (Hizmet ve Personel seçimi)
        [HttpGet]
        [Route("api/Personel/randevual")]
                   public IActionResult RandevuAl()
{
    var hizmetler = _context.Hizmet
        .Select(h => new SelectListItem
        {
            Value = h.HizmetID.ToString(),
            Text = h.HizmetAdi
        })
        .ToList();

    var personeller = _context.Personel
        .Select(p => new SelectListItem
        {
            Value = p.PersonelID.ToString(),
            Text = p.AdSoyad
        })
        .ToList();

    ViewData["Hizmet"] = hizmetler;
    ViewData["Personel"] = personeller;

    return View();
}


// POST: RandevuAl (Randevu Kaydetme)
    [HttpPost]
    public IActionResult RandevuAl(Randevu randevu)
    {
        if (ModelState.IsValid)
        {
            // Veritabanına randevuyu ekliyoruz
            _context.Randevu.Add(randevu);
            _context.SaveChanges();

            // Kaydedildikten sonra başarılı mesajı veya yönlendirme
            TempData["SuccessMessage"] = "Randevunuz başarıyla kaydedildi.";
            return RedirectToAction("Index", "Home");  // Anasayfa veya başka bir sayfaya yönlendirme
        }

        // Eğer model geçersizse tekrar formu göster
        return View(randevu);
    }
        // GET: Randevu/Create (Randevu oluşturma formu)
        [HttpGet]
        [Route("api/Personel/randevu/create")]
        public IActionResult Create()
        {
            // Hizmetler ve Personel verilerini çekiyoruz
            var hizmetList = _context.Hizmet.ToList();
            var personelList = _context.Personel.ToList();

            // Dropdown için ViewData'ya aktarın
            ViewData["Hizmet"] = new SelectList(hizmetList, "HizmetID", "HizmetAdi");
            ViewData["Personel"] = new SelectList(personelList, "PersonelID", "AdSoyad");

            return View();
        }

        // POST: Randevu/Create (Randevu kaydetme işlemi)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                // Veritabanına kaydet
                _context.Randevu.Add(randevu);
                await _context.SaveChangesAsync();
                 TempData["SuccessMessage"] = "Randevunuz başarıyla kaydedildi.";
                return RedirectToAction(nameof(Index)); // Başka bir sayfaya yönlendirebilirsiniz
            }

            // Model geçerli değilse tekrar formu göster
            ViewData["Hizmet"] = new SelectList(_context.Hizmet, "HizmetID", "HizmetAdi", randevu.HizmetID);
            ViewData["Personel"] = new SelectList(_context.Personel, "PersonelID", "AdSoyad", randevu.PersonelID);
            return View(randevu);
        }

        // GET: Randevu/Index (Randevu listesi)
        [HttpGet]
        [Route("api/Personel/randevu/index")]
        public async Task<IActionResult> Index()
        {
            var randevular = await _context.Randevu
                                          .Include(r => r.Hizmet) // Hizmetle ilişkili veriyi ekle
                                          .Include(r => r.Personel) // Personelle ilişkili veriyi ekle
                                          .ToListAsync();
            return View(randevular);
        }
    }
}
