using OOPOdev.Models;
using System.Globalization;

namespace OOPOdev.Data
{
    public static class Veriler
    {
        public static string KayitBulunamadiMesaji => "Kayıt bulunamdı.";

        public static string HataMesaji => "İşlem sırasında hata meydana geldi";

        public static int EnSonId { get; set; } = 1;

        public static List<Kitap> Kitaplar { get; set; } 

        public static List<Yazar> Yazarlar { get; set; }

        static Veriler()
        {
            Yazarlar = new List<Yazar>()
            {
                new Yazar()
                {
                    Id = EnSonId++,
                    Adi = "Fyodor", 
                    Soyadi = "Dostoyevski",
                    DogumTarihi = DateTime.Parse("11.11.1821", new CultureInfo("tr-TR")),

                    EmekliMi = true
                },

                new Yazar()
                {
                    Id = EnSonId++,
                    Adi = "Jack",
                    Soyadi = "London",
                    DogumTarihi = DateTime.Parse("12.01.1876", new CultureInfo("tr-TR")),
                    EmekliMi = false

                }
            };

            Kitaplar = new List<Kitap>()
            {
                new Kitap()
                {
                    Id = EnSonId++ ,
                    Adi = "Suç ve Ceza",
                    YayinYili = 1866,
                    Fiyat = 80.0m,
                    BasimTarihi = DateTime.Parse("01.09.2014", new CultureInfo("tr-TR")),
                    Yazari = Yazarlar.FirstOrDefault()
                },

                new Kitap()
                {
                    Id = EnSonId++ ,
                    Adi = "Beyaz Diş",
                    YayinYili = 1906,
                    Fiyat = 70.0m,
                    BasimTarihi = DateTime.Parse("08.07.2011", new CultureInfo("tr-TR")),
                    Yazari = Yazarlar.LastOrDefault()

                }
                 
            };

            
        }

        public static string KayitSayisiMesajiGetir(int kayitSayisi) => kayitSayisi == 0 ? KayitBulunamadiMesaji : kayitSayisi + " kayıt bulundu.";
        
    }
}
