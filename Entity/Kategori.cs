using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Kategori
    {
        public Kategori()
        {
            Yazilar = new List<Yazi>();
        }
        [Key]
        public int KategoriId { get; set; }
        public string KategoriBaslik { get; set; }
        public string KategoriIcerik { get; set; }
        public virtual List<Yazi> Yazilar { get; set; }
    }
}
