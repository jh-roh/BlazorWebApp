using BlazorWebApp.BlazorServer.Data;
using BlazorWebApp.BlazorServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWebApp.BlazorServer.Services
{
    public class CategoryService
    {

        private readonly BlogContext _context;

        public CategoryService(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync() =>
            await _context.Categories.AsNoTracking().ToListAsync();
    }
}
