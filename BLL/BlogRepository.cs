using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BlogRepository
    {
        private BlogContext db = new BlogContext();
        public Yazi YaziGetir(int id)
        {
            return db.Yazilar.Find(id);
        }

        public List<Yazi> ButunYazilariGetir()
        {
            return db.Yazilar.ToList();
        }
        public List<Yazi> YaziAra(string arananYazi)
        {
            return db.Yazilar.Where(x => x.YaziIcerigi.Contains(arananYazi)).ToList();
        }
        public Yazi YaziEkle(Yazi yeniYazi)
        {
            return db.Yazilar.Add(yeniYazi);
        }
        public void YaziSil(int id)
        {
            db.Yazilar.Remove(YaziGetir(id));
            db.SaveChanges();
        }
        public void UpdateArticle(Yazi guncellenenYazi)
        {
            var original = YaziGetir(guncellenenYazi.YaziId);
            original.YaziIcerigi = guncellenenYazi.YaziIcerigi;
            original.SeoTitle = guncellenenYazi.SeoTitle;
            original.SeoDesc = guncellenenYazi.SeoDesc;
            original.SeoKeywords = guncellenenYazi.SeoKeywords;
            db.Entry(original).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
