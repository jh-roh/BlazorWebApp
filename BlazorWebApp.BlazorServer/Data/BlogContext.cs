using BlazorWebApp.BlazorServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorWebApp.BlazorServer.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Entities.BlogPost> BlogPosts { get; set; }

        public DbSet<Entities.Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer("Server=.;Database=BlazorWebApp;Trusted_Connection=True;");

#if DEBUG
            optionsBuilder.LogTo(Console.WriteLine);

#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasData( 
                    new User
                    { 
                        Id = 1, 
                        Email = "test1234@naver.com",
                        FirstName = "Test1",
                        LastName = "User1",
                        Salt = "Dummy Data",
                        Hash = "sadg23h65jh!@$^%HGD",

                    });

        }

    }
}
