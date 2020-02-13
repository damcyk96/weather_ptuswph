using System;

namespace WebApplication12.Messages.Responses
{
    public class BlogResponse
    {
        public Guid Id { get; }
        public string Name { get; }
        public DateTime CreatedOn { get; }
        public string AuthorFirstName { get; }
        public string AuthorLastName { get; }

        public BlogResponse(Guid id, string name, DateTime createdOn, string authorFirstName, string authorLastName)
        {
            Id = id;
            Name = name;
            CreatedOn = createdOn;
            AuthorFirstName = authorFirstName;
            AuthorLastName = authorLastName;
        }
    }
}