using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{  
    public class AdminController : Controller
    {
        // Personel İşlemleri
        public IActionResult PersonelIslemleri()
        {
            return PartialView("_PersonelIslemleri");
        }

        // Hizmet İşlemleri
        public IActionResult HizmetIslemleri()
        {
            return PartialView("_HizmetIslemleri");
        }

        // Randevu İşlemleri
        public IActionResult RandevuIslemleri()
        {
            return PartialView("_RandevuIslemleri");
        }

        // Kullanıcı İşlemleri
        public IActionResult KullaniciIslemleri()
        {
            return PartialView("_KullaniciIslemleri");
        }
    }
   
}
