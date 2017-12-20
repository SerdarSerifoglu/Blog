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
        public class KategoriRep : BaseRepository<Kategori> { }
        public class YaziRep : BaseRepository<Yazi> { }
        public class YorumRep : BaseRepository<Yorum> { }
        public class LikeRep : BaseRepository<Like> { }
    }
}
