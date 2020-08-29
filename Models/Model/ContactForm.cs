using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlogProject.Models.Model
{
    public class ContactForm
    {
        public int ContactFormId { get; set; }

       
        [StringLength(50, ErrorMessage = "50 karakterden fazla giriş yapamazsınız.")]
        [Required(ErrorMessage = "Gerekli Alan")]
        public string Namesurname { get; set; }

        [Required(ErrorMessage = "Gerekli Alan")]
        [StringLength(50, ErrorMessage = "50 karakterden fazla giriş yapamazsınız.")]
        
        public string Email { get; set; }

        [Required(ErrorMessage = "Gerekli Alan")]
        [StringLength(50, ErrorMessage = "50 karakterden fazla giriş yapamazsınız.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Gerekli Alan")]
        [StringLength(500, ErrorMessage = "500 karakterden fazla giriş yapamazsınız.")]
        public string Message { get; set; }
    }
}