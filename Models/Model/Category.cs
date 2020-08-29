using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlogProject.Models.Model
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DisplayName("Kategori Id")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Kategori Adı"), StringLength(50, ErrorMessage = "550 karakterden fazla giriş yapamazsınız!")]
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}