using BlazorWebApp.BlazorServer.Data;
using BlazorWebApp.BlazorServer.Data.Entities;
using BlazorWebApp.BlazorServer.Extensions;
using BlazorWebApp.BlazorServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

        public async Task<MethodResult> SaveCategoryAsync(Category model)
        {
            try
            {
                if (model.Id > 0)
                {
                    _context.Categories.Update(model);
                }
                else
                {
                    model.Slug = model.Slug.Slugify();
                    await _context.Categories.AddAsync(model);
                }

                await _context.SaveChangesAsync();

                return MethodResult.Success();
            }
            catch (Exception ex)
            {
                //log Exception
                return MethodResult.Failure(ex.Message);

            }
        }

        
        
    }
}
