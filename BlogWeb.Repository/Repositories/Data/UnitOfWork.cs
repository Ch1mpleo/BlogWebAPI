using BlogWeb.Repository.Entities;
using BlogWeb.Repository.Interfaces.Data;
using BlogWeb.Repository.Interfaces.IGenericRepo;
using BlogWeb.Repository.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWeb.Repository.Repositories.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext _dbContext;

        public UnitOfWork(BlogDbContext dbContext)
        {
            _dbContext = dbContext;

            BlogPostRepository = new GenericRepository<BlogPost>(_dbContext);
            CategoryRepository = new GenericRepository<Category>(_dbContext);
            CommentRepository = new GenericRepository<Comment>(_dbContext);
            LikeRepository = new GenericRepository<Like>(_dbContext);
            // Initialize other repositories here
        }

        public IGenericRepository<BlogPost> BlogPostRepository { get; private set; }
        public IGenericRepository<Category> CategoryRepository { get; private set; }
        public IGenericRepository<Comment> CommentRepository { get; private set; }
        public IGenericRepository<Like> LikeRepository { get; private set; }
        // Add properties for other repositories

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
