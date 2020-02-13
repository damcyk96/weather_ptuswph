using System;
using Blog.Models;
using FluentValidation;

namespace WebApplication12.Messages.Requests
{
    public class CreateBlogRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public Author Author { get; set; }
    }

    public class CreateBlogRequestValidator : AbstractValidator<CreateBlogRequest>
    {
        public CreateBlogRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().Length(5, 20);
        }
    }
}