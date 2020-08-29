using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlogProject.Models.Model
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [DisplayName("Email"),StringLength(50,ErrorMessage ="50 karakterden fazla giriş yapamazsınız.")]
        public string Email { get; set; }
        [DisplayName("Çalışma Saatleri"), StringLength(50, ErrorMessage = "50 karakterden fazla giriş yapamazsınız.")]
        public string WorkHours { get; set; }
    }
}