using BlogWeb.Repository.Entities;
using BlogWeb.Repository.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWeb.Repository.Interfaces
{
    public interface IBlogPostRepository : IGenericRepository<BlogPost>
    {
        Task<IEnumerable<BlogPost>> GetByAuthorIdAsync(string authorId);
        Task<IEnumerable<BlogPost>> GetByCategoryIdAsync(Guid categoryId);
        Task<IEnumerable<BlogPost>> GetByTitleAsync(string title);
        Task<IEnumerable<BlogPost>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        
    }
}
