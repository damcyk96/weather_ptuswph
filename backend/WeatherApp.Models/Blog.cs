using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public Author Author { get; set; }
        public ICollection<Post> Posts { get; set; }

        public Blog(Guid id, string name, DateTime createdOn, Author author, ICollection<Post> posts = null)
        {
            Id = id;
            Name = name;
            CreatedOn = createdOn;
            Author = author;
            Posts = posts ?? new List<Post>();
        }
    }
}