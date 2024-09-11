using BlogWeb.Repository.Entities;
using BlogWeb.Repository.Interfaces.IGenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWeb.Repository.Interfaces.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<BlogPost> BlogPostRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<Comment> CommentRepository { get; }
        IGenericRepository<Like> LikeRepository { get; }
        // Add more repositories as needed

        Task<int> CompleteAsync(); // Save changes across all repositories
    }
}
