using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWeb.Repository.Entities
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }    // Lưu cả HTML rich-text dô
        public string BriefSummary { get; set; }    // Brief overview khi list ngoài page
        public string? Slug { get; set; }       // URL friendly
        public string ImageTitle { get; set; }   // Ảnh cho bài blog - sẽ hiện khi view page


        // Key
        public string AuthorId { get; set; } 

        // Navigation properties
        [ForeignKey("AuthorId")]
        public virtual IdentityUser Author { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<BlogPostCategory> BlogPostCategories { get; set; }
    }
}
