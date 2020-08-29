using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlogProject.Models.Model
{
    [Table("Newsletter")]
    public class Newsletter
    {
        [Key]
        public int NewsletterId { get; set; }
        [DisplayName("Email"),StringLength(200,ErrorMessage ="200 karakterden fazla giriş yapamazsınız.")]
        public string Email { get; set; }
    }
}