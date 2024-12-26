using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Randevu
    {
        public int RandevuID { get; set; }
    public int KullaniciID { get; set; }
    public int HizmetID { get; set; }
    public int PersonelID { get; set; }
    public DateTime Tarih { get; set; }
      public string Status { get; set; } 
    public Kullanici Kullanici { get; set; }
    public Hizmet Hizmet { get; set; }
    public Personel Personel { get; set; }
    }
}
