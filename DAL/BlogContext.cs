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
    public class BlogContext: IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<Yazi> Yazilar { get; set; }
    }
}
