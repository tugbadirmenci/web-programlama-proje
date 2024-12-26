using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class RandevuController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RandevuController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Tüm randevuları getir
    [HttpGet]
    public IActionResult GetAll()
    {
        var randevular = _context.Randevu
            .Include(r => r.Kullanici)
            .Include(r => r.Personel)
            .Include(r => r.Hizmet)
            .ToList();

        return Ok(randevular);
    }

    // Randevu ekle
    [HttpPost]
    public IActionResult Add(Randevu randevu)
    {
        _context.Randevu.Add(randevu);
        _context.SaveChanges();
        return Ok(randevu);
    }

    // Randevu sil
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var randevu = _context.Randevu.FirstOrDefault(r => r.RandevuID == id);
        if (randevu == null)
        {
            return NotFound();
        }

        _context.Randevu.Remove(randevu);
        _context.SaveChanges();
        return NoContent();
    }

    // Randevu durumu onayla
    [HttpPut("approve/{id}")]
    public IActionResult Approve(int id)
    {
        var randevu = _context.Randevu.FirstOrDefault(r => r.RandevuID == id);
        if (randevu == null)
        {
            return NotFound();
        }

        randevu.Status = "Onaylandı";
        _context.SaveChanges();
        return Ok(randevu);
    }
}
