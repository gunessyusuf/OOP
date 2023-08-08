using OOPOdev.Data;
using OOPOdev.Models;
using OOPOdev.Models.Bases;
using OOPOdev.Services.Bases;

namespace OOPOdev.Services
{
    public class YazarService : IService
    {
        public List<Yazar> YazarlariGetir()
        {
            return Veriler.Yazarlar;
        }
        public Kayit KayitGetir(int id)
        {
            

           return YazarlariGetir().FirstOrDefault(varolanYazarlar => varolanYazarlar.Id == id);

            
        }
    }
}
