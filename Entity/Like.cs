using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Like
    {
        public Like()
        {
            LikeTarihi = DateTime.Now;
        }
        [Key]
        public int LikeId { get; set; }
        public string UyeIdLike { get; set; }
        public Yazi LikelananYazi { get; set; }
        public DateTime LikeTarihi { get; set; }
    }
}
