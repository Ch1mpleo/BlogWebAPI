using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWeb.Repository.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string? Slug { get; set; }

        // Navigation properties
        public virtual ICollection<BlogPostCategory> BlogPostCategories { get; set; }
    }
}
