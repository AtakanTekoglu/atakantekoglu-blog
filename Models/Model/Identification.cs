using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlogProject.Models.Model
{
    [Table("Identification")]
    public class Identification
    {
        [Key]
        public int IdentificationId { get; set; }
        [DisplayName("Başlık"), StringLength(50, ErrorMessage = "50 karakter sınırı!")]
        public string Title { get; set; }
        [DisplayName("Anahtar Kelimeler"), StringLength(int.MaxValue)]
        public string Keywords { get; set; }
        [DisplayName("Açıklama"), StringLength(int.MaxValue)]
        public string Description { get; set; }
        [DisplayName("Logo Resim Yolu"), StringLength(int.MaxValue)]
        public string LogoURL { get; set; }

    }
}