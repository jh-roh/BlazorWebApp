using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.BlazorServer.Data.Entities
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }

        public string Introduction { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublished { get; set; }

        public DateTime? PublicshedOn { get; set; }
    }

}
