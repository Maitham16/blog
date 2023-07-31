// create post model
using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ShortDesc { get; set; }
        public string? Body { get; set; }
        public DateTime Posted { get; set; }
    }
}