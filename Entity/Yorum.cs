using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Yorum
    {
        public Yorum()
        {
            YorumTarihi = DateTime.Now;
        }
        [Key]
        public int YorumId { get; set; }
        [Required]
        [StringLength(100,ErrorMessage ="Yorum başlığı 100 karakterden fazla olamaz")]
        public string YorumBaslik { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Yorum içeriği 500 karakterden fazla olamaz")]
        public string YorumIcerik { get; set; }
        public Yazi YorumlananYazi { get; set; }
        public string YorumlayanUyeId { get; set; }
        public DateTime YorumTarihi { get; set; }
    }
}
