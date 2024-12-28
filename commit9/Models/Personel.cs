namespace WebApplication1.Models
{
    public class Personel
    {
        public int PersonelID { get; set; } // Personel için benzersiz ID
        public string? AdSoyad { get; set; } // Personelin adı      
       public bool MusaitlikDurumu { get; set; }
        public string? UzmanlikAlani { get; set; } // Personelin uzmanlık alanı (örneğin, kuaför, manikür vb.)
    }
}
