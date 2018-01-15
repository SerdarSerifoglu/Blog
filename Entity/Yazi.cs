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
            YaziYorumlari = new List<Yorum>();
            YaziLikelari = new List<Like>();
            BegenilmeSayisi = 0;
            OkunmaSayisi = 1;
        }
        [Key]
        public int YaziId { get; set; }
        public string KullaniciId { get; set; }
        [Required]
        public int KategoriId { get; set; }
        [Required]
        [StringLength(150,ErrorMessage ="Başlık 150 karakterden fazla girilemez.")]
        public string YaziBasligi { get; set; }
        [Required(ErrorMessage = "Yazı içeriği boş bırakılamaz.")]
        [Column(TypeName = "text")]
        public string YaziIcerigi { get; set; }
        [StringLength(20,ErrorMessage ="Etiket 20 karakterden fazla girilemez.")]
        public string Etiket1 { get; set; }
        [StringLength(20, ErrorMessage = "Etiket 20 karakterden fazla girilemez.")]
        public string Etiket2 { get; set; }
        [StringLength(20, ErrorMessage = "Etiket 20 karakterden fazla girilemez.")]
        public string Etiket3 { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        
        [Required(ErrorMessage = "Seo Title bölümü boş bırakılamaz.")]
        [StringLength(57, ErrorMessage = "Seo Title yazısı 57 karakteri geçmemelidir.")]
        public string SeoTitle { get; set; }
        [Required(ErrorMessage = "Seo Description bölümü boş bırakılamaz")]
        [StringLength(160, ErrorMessage = "Seo Description yazısı 160 karakteri geçmemelidir.")]
        public string SeoDesc { get; set; }
        public string SeoKeywords { get; set; }
        public int? BegenilmeSayisi { get; set; }
        public int? OkunmaSayisi { get; set; }
        public virtual List<Yorum> YaziYorumlari { get; set; }
        public virtual List<Like> YaziLikelari { get; set; }



    }
}
