using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlogProject.Models.Model
{
    [Table("SocialMedia")]
    public class SocialMedia
    {
        [Key]
        public int SocialMediaId { get; set; }
        [DisplayName("İnstagram"),StringLength(100,ErrorMessage ="100 karakterden fazla giriş yapamazsınız.")]
        public string Instagram { get; set; }
        [DisplayName("Linkedin"), StringLength(100, ErrorMessage = "100 karakterden fazla giriş yapamazsınız.")]
        public string Linkedin { get; set; }
        [DisplayName("Github"), StringLength(100, ErrorMessage = "100 karakterden fazla giriş yapamazsınız.")]
        public string Github { get; set; }
    }
}