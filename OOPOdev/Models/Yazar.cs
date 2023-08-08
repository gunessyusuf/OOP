using OOPOdev.Models.Bases;

namespace OOPOdev.Models
{
    public class Yazar : Kayit
    {
        public string? Adi { get; set; } // Adi özelliği  null değer alabileceği için ? kullanıldı.

        public string? Soyadi { get; set; }  // Soyadi özelliği  null değer alabileceği için ? kullanıldı.

        public DateTime DogumTarihi { get; set; }

        public bool EmekliMi { get; set; }


    }
}
