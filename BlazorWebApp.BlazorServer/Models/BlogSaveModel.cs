﻿using BlazorWebApp.BlazorServer.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.BlazorServer.Models
{
    public class BlogSaveModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(120)]
        public string Title { get; set; }

        [Required, MaxLength(150)]

        public string Slug { get; set; }


        public int CategoryId { get; set; }

        public int UserId { get; set; }

        [Required, MaxLength(250)]
        public string Introduction { get; set; }

        public string Content { get; set; }

        public bool IsPublished { get; set; }

        public BlogPost ToBlogEntity(int userId) =>
            new ()
            {

                Id = Id,
                Title = Title,
                Slug = Slug,
                CategoryId = CategoryId,
                Introduction = Introduction,
                Content = Content,
                IsPublished = IsPublished,
                UserId = userId
            };

    }
}
