namespace WebApplication1.Models
{
    public class Hizmet
    {
        public decimal Ucret { get; set; }
        public int HizmetID { get; set; } // Hizmet için benzersiz ID
        
        public string HizmetAdi { get; set; } // Hizmet adı (örneğin, "Saç Kesimi", "Manikür")
       public int Sure { get; set; } 
    }
}
