using Microsoft.EntityFrameworkCore;
using WebApplication1.Models; // DbContext ve modellerinizi kullanmak için
using WebApplication1.Data;  // ApplicationDbContext'in bulunduğu namespace
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApplication1.Services;
using WebApplication1.Controllers;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Veritabanı bağlantısını ayarla
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Controller'ları ekle
builder.Services.AddControllersWithViews();

// AccountController'ı DI container'a ekleyin
builder.Services.AddScoped<AccountController>();

// AdminService'i DI konteynerine ekleyin
builder.Services.AddScoped<AdminService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Diğer servisleri ekleyin (örneğin, controller'lar)
builder.Services.AddControllersWithViews();

var app = builder.Build();


// Middleware (uygulama hattı) ayarları
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
 
// Eğer girişte `/Account/Register` sayfasına yönlendirme yapmak istiyorsanız, aşağıdaki gibi yapabilirsiniz:
app.MapControllerRoute(
    name: "register",
    pattern: "Account/Register",  // Burada URL deseni belirlenir.
    defaults: new { controller = "KayitOl", action = "Register" }  // Burada ise yönlendirdiğiniz controller ve action belirtilir.
);
// AdminLogin view ve Dashboard route'u tanımlanır
app.MapControllerRoute(
    name: "adminLogin",
    pattern: "admin/login",
    defaults: new { controller = "Account", action = "AdminLogin" });

app.MapControllerRoute(
    name: "dashboard",
    pattern: "admin/dashboard",
    defaults: new { controller = "Account", action = "Dashboard" });
// Varsayılan rota
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
