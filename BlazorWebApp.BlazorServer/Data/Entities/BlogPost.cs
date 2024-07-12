﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.BlazorServer.Data.Entities
{
    public class BlogPost
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

        [Required]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublished { get; set; }

        public DateTime? PublicshedOn { get; set; }
    }

}
