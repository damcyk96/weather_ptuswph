using System;

namespace WebApplication12.Messages.Responses
{
    public class PostDetailsResponse
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Content { get; }
        public DateTime CreatedOn { get; }

        public PostDetailsResponse(Guid id, string title, string content, DateTime createdOn)
        {
            Id = id;
            Title = title;
            Content = content;
            CreatedOn = createdOn;
        }
    }
}