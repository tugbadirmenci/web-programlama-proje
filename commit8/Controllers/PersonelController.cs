using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PersonelController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PersonelController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Personel Listeleme
    [HttpGet]
    public IActionResult GetPersonel()
    {
        var personeller = _context.Personel
            .Select(p => new
            {
                p.PersonelID,
                p.Ad,
                p.Soyad,
                p.UzmanlikAlani,
                Durum = p.MusaitlikDurumu ? "Müsait" : "Meşgul"
            })
            .ToList();
        return Ok(personeller);
    }

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
