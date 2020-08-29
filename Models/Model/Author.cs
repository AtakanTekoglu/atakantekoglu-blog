using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace MyBlogProject.Models.Model
{
    [Table("Author")]
    public class Author
    {
        [Key]
        [DisplayName("Yazar Id")]
        public int AuthorId { get; set; }

        [Required]
        [DisplayName("Yazar Adı"),StringLength(50,ErrorMessage ="50 karakterden fazla giriş yapamazsınız.")]
        public string AuthorName { get; set; }

        [Required]
        [DisplayName("Yazar Soyadı"), StringLength(50, ErrorMessage = "50 karakterden fazla giriş yapamazsınız.")]
        public string AuthorSurname { get; set; }

        [Required]
        [DisplayName("Email"),StringLength(50,ErrorMessage ="50 karakterden fazla giriş yapamazsınız.")]
        public string Email { get; set; }

        public int? GalleryId { get; set; }
        public Gallery Gallery { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}