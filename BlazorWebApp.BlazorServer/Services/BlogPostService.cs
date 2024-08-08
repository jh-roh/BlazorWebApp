using BlazorWebApp.BlazorServer.Data;
using BlazorWebApp.BlazorServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWebApp.BlazorServer.Services
{
    public class BlogPostService
    {
        private readonly BlogContext _context;

        public BlogPostService(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogPost>> GetBlogsAsync() =>
            await _context.BlogPosts.AsNoTracking().ToListAsync();


        public async Task SaveAsync(BlogPost post)
        {

        }
    }
}
