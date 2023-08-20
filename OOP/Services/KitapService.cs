using OOPOdev.Data;
using OOPOdev.Models;
using OOPOdev.Models.Bases;
using OOPOdev.Services.Bases;

namespace OOPOdev.Services
{
    public class KitapService : IService
    {
        public List<Kitap> KitaplariGetir()
        {
            return Veriler.Kitaplar;
        }


        public Kayit KayitGetir(int id)
        {
            return KitaplariGetir().FirstOrDefault(film => film.Id == id);

        }

        public List<Kitap> KitaplariGetir(string adi)
        {
            List<Kitap> kitaplar = new List<Kitap>();
            List<Kitap> varolanKitaplar = KitaplariGetir();

            foreach (Kitap varolanKitap in varolanKitaplar)
            {
                if (varolanKitap.Adi.Contains(adi, StringComparison.OrdinalIgnoreCase))
                {
                    kitaplar.Add(varolanKitap);
                }
            }

            return kitaplar;
        }

        public Kitap KitapGetir(string adi, int id = 0)
        {
            if (id == 0)
            {
                return KitaplariGetir().FirstOrDefault(kitap => kitap.Adi.Equals(adi, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                return KitaplariGetir().FirstOrDefault(kitap => kitap.Adi.Equals(adi, StringComparison.OrdinalIgnoreCase) && kitap.Id == id);
            }
        }

        public string KitapEkle(Kitap kitap)
        {
            if (KitapGetir(kitap.Adi) is not null)
            {
               return "Girilen ada sahip kitap bulunmaktadır!";
               
            }

            kitap.Id = Veriler.EnSonId;
            Veriler.EnSonId++;
            Veriler.Kitaplar.Add(kitap);

            return "Kitap başarıyla eklendi.";

        }

        public string KitapGuncelle(Kitap kitap)
        {
            if (KitapGetir(kitap.Adi, kitap.Id) is not null)
            {
                return "Girilen ada sahip kitap bulunmaktadır.";
                
            }

            Kayit varolanKayit = KayitGetir(kitap.Id);

            Kitap varolanKitap = varolanKayit as Kitap;

            varolanKitap.Adi = kitap.Adi.Trim();
            varolanKitap.BasimTarihi = kitap.BasimTarihi;
            varolanKitap.Yazari = kitap.Yazari;
            varolanKitap.Fiyat = kitap.Fiyat;
            return "Kitap başarıyla güncellendi.";
        }

        public string KitapSil(int id)
        {
            Kayit varolanKitap = KayitGetir(id);

            if (varolanKitap is null)
            {
                return Veriler.KayitBulunamadiMesaji;
            }

            List<Kitap> varolanKitaplar = KitaplariGetir();
            varolanKitaplar.Remove((Kitap)varolanKitap);
            return "Kitap başarıyla silindi.";
        }
    }
}
