using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class KayitOlController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KayitOlController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KayitOl
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: KayitOl
        [HttpPost]
        public async Task<IActionResult> Register(KullaniciViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Şifreyi hash'lemek için SHA256 kullanılabilir
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(model.Sifre));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    model.Sifre = builder.ToString(); // Şifreyi hash'leyerek kaydediyoruz
                }

                // Kullanıcı modelini veritabanına kaydediyoruz
                var kullanici = new Kullanici
                {
                    Ad = model.Ad,
                    Soyad = model.Soyad,
                    Email = model.Email,
                    Sifre = model.Sifre
                };

                _context.Kullanici.Add(kullanici);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");  // Kayıt başarılı olduktan sonra ana sayfaya yönlendirme
            }

            return View(model);  // Hata durumunda form tekrar gösterilir
        }
    }
}
