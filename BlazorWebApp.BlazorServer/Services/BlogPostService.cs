using BlazorWebApp.BlazorServer.Data;
using BlazorWebApp.BlazorServer.Data.Entities;
using BlazorWebApp.BlazorServer.Extensions;
using BlazorWebApp.BlazorServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
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


        public async Task<MethodResult> SaveAsync(BlogSaveModel post, int userId)
        {
            var entity = post.ToBlogEntity(userId);

            if(entity.Id == 0)
            {
                //Creating a new blog post
                entity.Slug = entity.Slug.Slugify();
                entity.CreatedOn = DateTime.Now;
                entity.ModifiedOn = DateTime.Now;   
                if(entity.IsPublished)
                {
                    entity.PublicshedOn = DateTime.Now;
                }

                await _context.AddAsync(entity);
            }
            else
            {
                //Updating an existing blog post 
            }

            try
            {
                if (await _context.SaveChangesAsync() > 0)
                {
                    return MethodResult.Success();
                }
                else
                {
                    return MethodResult.Failure("Unknown error occured while saving the blog post");
                }
            }
            catch (Exception ex)
            {
                return MethodResult.Failure(ex.Message);
            }

        }
    }
}
