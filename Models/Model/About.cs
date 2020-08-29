using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlogProject.Models.Model
{
    [Table("About")]
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        [Required]
        [DisplayName("Başlık"),StringLength(50,ErrorMessage ="50 karakter sınırı!")]
        public string Title { get; set; }
        [Required]
        [DisplayName("İçerik"), StringLength(int.MaxValue)]
        public string Content { get; set; }
        [DisplayName("Resim URL"), StringLength(1000, ErrorMessage = "1000 karakter sınırı!")]
        public string ImageURL { get; set; }

        [DisplayName("İlgi Alanları"), StringLength(1000, ErrorMessage = "1000 karakter sınırı!")]
        public string Skill { get; set; }
    }
}