using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // Kullanıcı Girişi
        public IActionResult Login()
        {
            return View();
        }

        // Admin Girişi
        public IActionResult AdminLogin()
        {
            return View();
        }

        // Kayıt Ol
        public IActionResult Register()
        {
            return View();
        }
    }
}
