using System;
using FluentValidation;

namespace WebApplication12.Messages.Requests
{
    public class CreatePostRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        public CreatePostRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().Length(5, 20);
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.CreatedOn).LessThanOrEqualTo(DateTime.Now);
        }
    }
}