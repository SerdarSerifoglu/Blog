﻿using System;
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
        }
        [Key]
        public int YaziId { get; set; }
        [ForeignKey("Kategori")]
        public int YaziKategoriId { get; set; }
        [Required]
        [StringLength(150,ErrorMessage ="Başlık 150 karakterden fazla girilemez.")]
        public string YaziBasligi { get; set; }
        [Required(ErrorMessage = "Yazı içeriği boş bırakılamaz.")]
        [Column(TypeName = "text")]
        public string YaziIcerigi { get; set; }
        [Required]
        public string Etiket { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public int BegenilmeSayisi { get; set; }


        [Required(ErrorMessage = "Seo Title bölümü boş bırakılamaz.")]
        [StringLength(57, ErrorMessage = "Seo Title yazısı 57 karakteri geçmemelidir.")]
        public string SeoTitle { get; set; }
        [Required(ErrorMessage = "Seo Description bölümü boş bırakılamaz")]
        [StringLength(160, ErrorMessage = "Seo Description yazısı 160 karakteri geçmemelidir.")]
        public string SeoDesc { get; set; }
        public string SeoKeywords { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual List<Yorum> YaziYorumlari { get; set; }
        public virtual List<Like> YaziLikelari { get; set; }



    }
}
