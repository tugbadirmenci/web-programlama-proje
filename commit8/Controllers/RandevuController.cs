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

    public RandevuController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: RandevuAl
    public IActionResult RandevuAl()
    {
        // Hizmetler ve personelleri dropdown için gönderelim
        ViewData["Hizmet"] = new SelectList(_context.Hizmet, "HizmetID", "HizmetAdi");
        ViewData["Personel"] = new SelectList(_context.Personel, "PersonelID", "AdSoyad"); // AdSoyad özelliğini gösterebilirsiniz
        return View();
    }

    // GET: Randevu/Create
    public IActionResult Create()
    {
        // Hizmetler ve personelleri dropdown için gönderelim
        ViewData["Hizmet"] = new SelectList(_context.Hizmet, "HizmetID", "HizmetAdi");
        ViewData["Personel"] = new SelectList(_context.Personel, "PersonelID", "AdSoyad"); // AdSoyad özelliğini gösterebilirsiniz
        return View();
    }

    // POST: Randevu/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Randevu randevu)
    {
        if (ModelState.IsValid)
        {
            // Veritabanına kaydet
            _context.Randevu.Add(randevu); // _context.Add yerine _context.Randevular.Add
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // Başka bir sayfaya yönlendirebilirsiniz
        }
        ViewData["Hizmet"] = new SelectList(_context.Hizmet, "HizmetID", "HizmetAdi", randevu.HizmetID);
        ViewData["Personel"] = new SelectList(_context.Personel, "PersonelID", "AdSoyad", randevu.PersonelID);
        return View(randevu);
    }

    // GET: Randevu/Index
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
