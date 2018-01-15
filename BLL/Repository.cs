using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class Repository
    {
      
        public class YaziRep : BaseRepository<Yazi>
        {
            public void OkunmaSayisiArttir(Yazi obj,int id)
            {
                obj = GetById(id);
                obj.OkunmaSayisi += 1;
                BlogContext.db.SaveChanges();
        }
        }
        public class YorumRep : BaseRepository<Yorum> { }
        public class LikeRep : BaseRepository<Like> { }
        public class KategoriRep : BaseRepository<Kategori> { }
    }
}
