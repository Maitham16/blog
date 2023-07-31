// Create Comment model
using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public DateTime Posted { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}