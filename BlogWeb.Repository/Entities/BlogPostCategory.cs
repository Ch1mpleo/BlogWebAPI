using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWeb.Repository.Entities
{
    public class BlogPostCategory : BaseEntity
    {
        // Key
        public Guid BlogPostId { get; set; }
        public Guid CategoryId { get; set; }

        // Navigation properties
        public virtual BlogPost BlogPost { get; set; }
        public virtual Category Category { get; set; }
    }
}
