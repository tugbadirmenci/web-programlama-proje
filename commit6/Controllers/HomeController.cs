using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
 
    // Randevu al sayfasına yönlendiren action
    public IActionResult RandevuAl()
    {
        return RedirectToAction("RandevuAl", "Randevu");  // RandevuController'a yönlendirme
    }
     // Hizmetler sayfasını göstermek için action
        public IActionResult Services()
        {
        var hizmetler = GetHizmetler(); // Hizmetleri alıyoruz
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


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
