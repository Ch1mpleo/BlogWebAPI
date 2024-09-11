using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWeb.Repository.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }


        // Key
        public Guid BlogPostId { get; set; }
        public string AuthorId { get; set; }

        // Navigation properties
        public virtual BlogPost BlogPost { get; set; }

        [ForeignKey("AuthorId")]
        public virtual IdentityUser Author { get; set; }
    }
}
