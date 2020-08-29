using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlogProject.Models.Model
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        [DisplayName("Admin Adı"), StringLength(70, ErrorMessage = "70 karakterden fazla giriş yapamazsınız.")]
        public string NameSurname { get; set; }
        [Required]
        [DisplayName("Email"), StringLength(50, ErrorMessage = "50 karakterden fazla giriş yapamazsınız.")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Şifre"), StringLength(100, ErrorMessage = "100 karakterden fazla giriş yapamazsınız.")]
        public string Password { get; set; }
    }
}