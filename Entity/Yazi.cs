using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Yazi
    {
        public Yazi()
        {
            EklenmeTarihi = DateTime.Now;
        }
        [Key]
        public int YaziId { get; set; }
        [Required(ErrorMessage = "Yazı içeriği boş bırakılamaz.")]
        [Column(TypeName = "text")]
        public string YaziIcerigi { get; set; }
        public DateTime EklenmeTarihi { get; set; }

        [Required(ErrorMessage = "Seo Title bölümü boş bırakılamaz.")]
        [StringLength(57, ErrorMessage = "Seo Title yazısı 57 karakteri geçmemelidir.")]
        public string SeoTitle { get; set; }
        [Required(ErrorMessage = "Seo Description bölümü boş bırakılamaz")]
        [StringLength(160, ErrorMessage = "Seo Description yazısı 160 karakteri geçmemelidir.")]
        public string SeoDesc { get; set; }
        public string SeoKeywords { get; set; }


    }
}
