using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PersonelController : ControllerBase
{
      [HttpGet("hizmetler")]
    public IActionResult GetHizmetler()
    {
        // Hizmetler verisini döndür
         var hizmetler = _context.Hizmet.Select(h => new { HizmetID = h.HizmetID, HizmetAdi = h.HizmetAdi }).ToList();
    return Ok(hizmetler);
    }

    [HttpGet("personeller")]
    public IActionResult GetPersoneller()
    {
        // Personeller verisini döndür
        var personeller = _context.Personel.Select(p => new { PersonelID = p.PersonelID, AdSoyad = p.AdSoyad }).ToList();
    return Ok(personeller);
    }
    private readonly ApplicationDbContext _context;

    public PersonelController(ApplicationDbContext context)
    {
        _context = context;
    }
  
[Route("api/[controller]")]



    // Personel Ekleme
    [HttpPost]
    public IActionResult AddPersonel([FromBody] Personel personel)
    {
        if (personel == null) return BadRequest("Geçersiz personel bilgisi.");

        _context.Personel.Add(personel);
        _context.SaveChanges();

        return Ok("Personel başarıyla eklendi.");
    }

   // Personel Silme
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersonel(int id)
    {
        var personel = await _context.Personel.FindAsync(id);

        if (personel == null)
        {
            return NotFound(); // Personel bulunamazsa 404 döner
        }

        _context.Personel.Remove(personel); // Veritabanından silme işlemi
        await _context.SaveChangesAsync();

        return NoContent(); // Silme işlemi başarılı
    }
}
