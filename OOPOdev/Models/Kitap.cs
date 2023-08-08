using OOPOdev.Models.Bases;

namespace OOPOdev.Models
{
    public class Kitap : Kayit
    {
        public string? Adi { get; set; }

        public short YayinYili { get; set; }

        public decimal Fiyat { get; set; }

        public string? YayinEvi { get; set; }

        public bool YerliMi { get; set; }

        public DateTime BasimTarihi { get; set; }

        public Yazar? Yazari { get; set; }


        // Adi, Yazari ve YayinEvi null değerler alabileceği için ? kullanıldı.
    }
}
