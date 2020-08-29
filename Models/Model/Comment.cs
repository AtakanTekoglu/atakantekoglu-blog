using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlogProject.Models.Model
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        [DisplayName("Ad Soyad"), StringLength(150, ErrorMessage = "150 karakterden fazla giriş yapamazsınız!")]
        public string NameSurname { get; set; }
        [Required]
        [DisplayName("Email"), StringLength(100, ErrorMessage = "100 karakterden fazla giriş yapamazsınız.")]
        public string Email { get; set; }
        [Required]
        [DisplayName("İçerik"), StringLength(int.MaxValue)]
        public string Content { get; set; }
        public bool IsApproved { get; set; }

        public int? ArticleId { get; set; }
        public Article Article { get; set; }
    }
}