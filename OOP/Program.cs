using OOPOdev.Data;
using OOPOdev.Models;
using OOPOdev.Models.Bases;
using OOPOdev.Services;
using System.Linq.Expressions;

namespace OOPOdev
{
    internal class Program
    {
        private static KitapService kitapService;
        private static YazarService yazarService;
        static void Main(string[] args)
        {
            kitapService = new KitapService();
            yazarService = new YazarService();

            int secim;

            do
            {
                MenuGetir();
                secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        KitapEkle();
                        break;
                    case 2:
                        KitaplariListele();
                        break;
                    case 3:
                        AdaGoreKitaplariListele();
                        break;
                    case 4:
                        IdyeGoreKitabiGoster();
                        break;
                    case 5:
                        KitapOlustur();
                        break;
                    case 6:
                        KitapGuncelle();
                        break;
                    case 7:
                        KitapSil();
                        break;
                    case 0:
                        Console.WriteLine("Programdan çıkış yaptınız...");
                        break;
                    default:
                        Console.WriteLine("Lütfen geçerli bir seçim yapınız!");
                        break;
                }

                Console.WriteLine();
            } while (secim != 0);
        }

        public static void MenuGetir()
        {




            Console.WriteLine(" 1: Kitap Ekle\n " +
                "2: Tüm Kitapları Listele\n " +
                "3: Ada Göre Kitapları Listele\n " +
                "4: Id'ye Göre Kitap Göster\n " +
                "5: Kitap Oluştur\n " +
                "6: Kitap Güncelle\n " +
                "7: Kitap Sil\n " +
                "0: Çıkış");

            Console.WriteLine("İslem Seçiniz:");

        }



        static void KitapEkle()
        {
            try
            {
                Kitap kitap = KitapOlustur();
                kitapService.KitapEkle(kitap);
                Console.WriteLine("Kitap başarıyla eklendi.");
            }
            catch
            {
                Console.WriteLine(Veriler.HataMesaji);
            }
        }

        public static void KitaplariListele()
        {
            List<Kitap> kitaplar = kitapService.KitaplariGetir();
            Yazdir(kitaplar);
            Console.WriteLine("Kayıt Sayısı: " + Veriler.KayitSayisiMesajiGetir(kitaplar.Count));
        }

        public static void AdaGoreKitaplariListele()
        {
            Console.Write("Kitap Adı: ");
            string adi = Console.ReadLine();
            List<Kitap> kitaplar = kitapService.KitaplariGetir(adi);
            Yazdir(kitaplar);
            Console.WriteLine("Kayıt Sayısı: " + Veriler.KayitSayisiMesajiGetir(kitaplar.Count));
        }


        public static void IdyeGoreKitabiGoster()
        {
            try
            {
                Console.Write("Kitap Id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Kayit kitap = kitapService.KayitGetir(id);
                if (kitap is not null)
                {
                    Yazdir((Kitap)kitap);
                }
                else
                {
                    Console.WriteLine(Veriler.KayitBulunamadiMesaji);
                }
            }
            catch
            {
                Console.WriteLine(Veriler.HataMesaji);
            }
        }


        public static Kitap KitapOlustur(int id = 0)
        {
            Kitap kitap = new Kitap();
            kitap.Id = id;

            Console.Write("Kitap Adı: ");
            kitap.Adi = Console.ReadLine();

            Console.Write("Yayın Yılı: ");
            kitap.YayinYili = Convert.ToInt16(Console.ReadLine());

            Console.Write("Fiyat: ");
            kitap.Fiyat = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Yayın Evi: ");
            kitap.YayinEvi = Console.ReadLine();

            Console.WriteLine("Yazarlar:");
            List<Yazar> yazarlar = yazarService.YazarlariGetir();
            Yazdir(yazarlar);

            Console.Write("Yazar Id: ");
            int yazarId = Convert.ToInt32(Console.ReadLine());
            Yazar yazar = (Yazar)yazarService.KayitGetir(yazarId);
            kitap.Yazari = yazar;

            return kitap;
        }

        public static void KitapGuncelle()
        {
            try
            {
                KitaplariListele();
                Console.Write("Güncellemek istediğiniz kitabın Id'sini girin: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Kitap kitap = KitapOlustur(id);
                kitapService.KitapGuncelle(kitap);
                Console.WriteLine("Kitap başarıyla güncellendi.");
            }
            catch
            {
                Console.WriteLine(Veriler.HataMesaji);
            }
        }

        public static void KitapSil()
        {
            try
            {
                KitaplariListele();
                Console.Write("Silmek istediğiniz kitabın Id'sini girin: ");
                int id = Convert.ToInt32(Console.ReadLine());
                kitapService.KitapSil(id);
                Console.WriteLine("Kitap başarıyla silindi.");
            }
            catch
            {
                Console.WriteLine(Veriler.HataMesaji);
            }
        }

        public static void Yazdir(Kitap kitap)
        {
            Console.WriteLine($"Id: {kitap.Id}");
            Console.WriteLine($"Adı: {kitap.Adi}");
            Console.WriteLine($"Yayın Yılı: {kitap.YayinYili}");
            Console.WriteLine($"Fiyat: {kitap.Fiyat}");
            Console.WriteLine($"Yayın Evi: {kitap.YayinEvi}");
            Console.WriteLine($"Yazar: {kitap.Yazari.Adi} {kitap.Yazari.Soyadi}");
        }

        public static void Yazdir(List<Kitap> kitaplar)
        {
            foreach (Kitap kitap in kitaplar)
            {
                Yazdir(kitap);
            }
        }

        public static void Yazdir(List<Yazar> yazarlar)
        {
            foreach (Yazar yazar in yazarlar)
            {
                Console.WriteLine($"Id: {yazar.Id}");
                Console.WriteLine($"Adı: {yazar.Adi}");
                Console.WriteLine($"Soyadı: {yazar.Soyadi}");
                Console.WriteLine($"Doğum Tarihi: {yazar.DogumTarihi}");
                Console.WriteLine($"Durumu: {(yazar.EmekliMi ? "Emekli" : "Çalışıyor")}");
            }

        }
    }
}