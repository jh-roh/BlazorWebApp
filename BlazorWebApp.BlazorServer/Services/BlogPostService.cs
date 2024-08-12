using BlazorWebApp.BlazorServer.Data;
using BlazorWebApp.BlazorServer.Data.Entities;
using BlazorWebApp.BlazorServer.Extensions;
using BlazorWebApp.BlazorServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            await _context.BlogPosts
                          .Include(p => p.Category)
                          .AsNoTracking().ToListAsync();

        public async Task<BlogSaveModel> GetPostAsync(int blogId) =>
            await _context.BlogPosts
                          .Include(p => p.Category)
                          .AsNoTracking()
                          .Select(BlogSaveModel.Selector)
                          .FirstOrDefaultAsync(p => p.Id == blogId);     

        public async Task<MethodResult> SaveAsync(BlogSaveModel post, int userId)
        {
            var entity = post.ToBlogEntity(userId);

            if(entity.Id == 0)
            {
                //Creating a new blog post
                entity.Slug = entity.Slug.Slugify();
                entity.CreatedOn = DateTime.Now;
                //entity.ModifiedOn = DateTime.Now;   
                if(entity.IsPublished)
                {
                    entity.PublicshedOn = DateTime.Now;
                }

                await _context.AddAsync(entity);
            }
            else
            {
                //Updating an existing blog post 
                BlogPost? bpEntity = await _context.BlogPosts
                                                   .FirstOrDefaultAsync(bp => bp.Id == post.Id);

                if(bpEntity  is not null)
                {
                    var wasEntityPublished = bpEntity.IsPublished;

                    bpEntity = post.Merge(bpEntity);

                    bpEntity.ModifiedOn = DateTime.Now;

                    if(bpEntity.IsPublished)
                    {
                        if(wasEntityPublished)
                        {
                            //Do nothing
                        }
                        else
                        {
                            //The blog post was not publishied in the db
                            //but user published it from the ui now
                            entity.PublicshedOn = DateTime.Now;
                        }
                    }
                    else if(wasEntityPublished)
                    {
                        // This blog post was published earlier in the db
                        // but user now un-published it from the ui
                        bpEntity.PublicshedOn = null;
                    }
                }
                else
                {
                    return MethodResult.Failure("This blog post does not exist"); 
                }
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
