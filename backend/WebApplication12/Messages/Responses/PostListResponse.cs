using System;

namespace WebApplication12.Messages.Responses
{
    public class PostListResponse
    {
        public Guid Id { get; }
        public string Title { get; }
        public DateTime CreatedOn { get; }

        public PostListResponse(Guid id, string title, DateTime createdOn)
        {
            Id = id;
            Title = title;
            CreatedOn = createdOn;
        }
    }
}