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
        public int YorumlananYaziId { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Yorum içeriği 500 karakterden fazla olamaz")]
        public string YorumIcerik { get; set; }
        public Yazi YorumlananYazi { get; set; }
        public string YorumlayanUyeId { get; set; }
        public string YotumlayanUsername { get; set; }
        public DateTime YorumTarihi { get; set; }
    }
}
