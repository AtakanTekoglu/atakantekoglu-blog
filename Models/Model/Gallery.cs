using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlogProject.Models.Model
{
    [Table("Gallery")]
    public class Gallery
    {
        [Key]
        public int GalleryId { get; set; }
        public string Description { get; set; }
        [DisplayName("Küçük Resim Yolu"),StringLength(500,ErrorMessage ="500 karakter sınırı vardır.")]
        public string MinPicURL { get; set; }
        [DisplayName("Orta Büyüklük Resim Yolu"), StringLength(500, ErrorMessage = "500 karakter sınırı vardır.")]
        public string MidPicURL { get; set; }
        [DisplayName("Büyük Resim Yolu"), StringLength(500, ErrorMessage = "500 karakter sınırı vardır.")]
        public string BigPicURL { get; set; }

        [DisplayName("Eklenme Tarihi")]
        public DateTime? Created { get; set; }

        public ICollection<Article> Articles { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}