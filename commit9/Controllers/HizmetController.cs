using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class HizmetController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public HizmetController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetHizmetler()
    {
        var hizmetler = _context.Hizmet
            .Select(h => new
            {
                h.HizmetID,
                h.HizmetAdi,
                h.Ucret,
                h.Sure
            })
            .ToList();
        return Ok(hizmetler);
    }

    [HttpPost]
    public IActionResult AddHizmet([FromBody] Hizmet hizmet)
    {
        if (hizmet == null) return BadRequest("Geçersiz hizmet bilgisi.");

        _context.Hizmet.Add(hizmet);
        _context.SaveChanges();

        return Ok("Hizmet başarıyla eklendi.");
    }

    // Hizmeti ID'ye göre alma (isteğe bağlı)
    [HttpGet("{id}")]
    public async Task<ActionResult<Hizmet>> GetHizmetById(int id)
    {
        var hizmet = await _context.Hizmet.FindAsync(id);

        if (hizmet == null)
        {
            return NotFound();
        }

        return hizmet;
    }
}

    

