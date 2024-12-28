using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Admin login page (Login form)
    public IActionResult AdminLogin()
    {
        return View();
    }

    // Admin login post action (Kullanıcı adı ve şifre kontrolü)
    [HttpPost]
    public IActionResult AdminLogin(string username, string password)
    {
        // Veritabanındaki admin ile karşılaştırma
        var admin = _context.Admins
                             .FirstOrDefault(a => a.Username == username && a.Password == password);

        if (admin != null)
        {
            // Giriş başarılıysa Admin Paneline yönlendir
            return RedirectToAction("Dashboard", "Admin");
        }

        // Hatalı giriş
        ViewData["ErrorMessage"] = "Geçersiz kullanıcı adı veya şifre!";
        return View();
    }

    // Admin Dashboard (Yönetim Paneli)
    public IActionResult Dashboard()
    {
        return View();
    }
}
