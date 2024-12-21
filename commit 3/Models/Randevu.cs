using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Randevu
    {
        public int RandevuID { get; set; }

        [Required]
        public int PersonelID { get; set; }
        public Personel? Personel { get; set; }  // Personel ile ilişkili

        [Required]
        public int HizmetID { get; set; }
        public Hizmet? Hizmet { get; set; }  // Hizmet ile ilişkili

        [Required]
        public DateTime RandevuTarihi { get; set; }  // Randevu tarihi
    }
}
