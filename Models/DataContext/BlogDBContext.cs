using MyBlogProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogProject.Models.DataContext
{
    public class BlogDBContext:DbContext
    {
        public BlogDBContext() : base("BlogDB")
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Identification> Identifications { get; set; }

        public System.Data.Entity.DbSet<MyBlogProject.Models.Model.Gallery> Galleries { get; set; }
    }
}