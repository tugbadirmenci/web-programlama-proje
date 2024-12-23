using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

    public class HizmetController : Controller
    {
       
        // Hizmetleri gösterecek bir action
        public IActionResult Index()
        {
            // Veritabanından veya sabit bir listeden hizmetleri alabilirsiniz
            var hizmetler = GetHizmetler();

            return View(hizmetler);
        }

        // Hizmetleri almak için basit bir metod
        private List<Hizmet> GetHizmetler()
        {
             return new List<Hizmet>
    {
        new Hizmet { HizmetID = 1, HizmetAdi = "Saç Kesimi", Ucret = 150, Sure = 30 },
        new Hizmet { HizmetID = 2, HizmetAdi = "Saç Boyama", Ucret = 200, Sure = 60 },
        new Hizmet { HizmetID = 3, HizmetAdi = "Manikür", Ucret = 100, Sure = 40 },
        new Hizmet { HizmetID = 4, HizmetAdi = "Pedikür", Ucret = 120, Sure = 50 },
        new Hizmet { HizmetID = 5, HizmetAdi = "Saç Bakımı", Ucret = 250, Sure = 90 }
    };
        }
    }

