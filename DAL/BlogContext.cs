using Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BlogContext : IdentityDbContext<IdentityUser>
    {
        public static BlogContext db = new BlogContext();

        public virtual DbSet<Yazi> Yazilar { get; set; }
        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<Like> Likelar { get; set; }
        public virtual DbSet<Yorum> Yorumlar { get; set; }
    }
}
