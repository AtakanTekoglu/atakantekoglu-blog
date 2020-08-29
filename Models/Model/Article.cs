using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Web;

namespace MyBlogProject.Models.Model
{
    [Table("Article")]
    public class Article
    {
        [Key]
        [DisplayName("Makale Id")]
        public int ArticleId { get; set; }

        [Required]
        [DisplayName("Başlık"),StringLength(150,ErrorMessage ="150 karakterden fazla giriş yapamazsınız!")]
        public string Title { get; set; }

        [Required]
        [DisplayName("İçerik"), StringLength(int.MaxValue)]
        public string Content { get; set; }

        [Required]
        [DisplayName("Yayınlanma Tarihi")]
        public DateTime? ReleaseDate { get; set; }

        public int? CategoryId{ get; set; }
        public Category Category { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        public int? GalleryId { get; set; }
        public Gallery Gallery { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}