using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Kullanici:IdentityUser
    {
        public virtual List<Yazi> KullaniciYazilari { get; set; }
        public virtual List<Yorum> KullaniciYorumlari { get; set; }
        public virtual List<Like> KullaniciLikelari { get; set; }
    }
}
