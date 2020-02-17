using System;
using FluentValidation;

namespace WebApplication12.Messages.Requests
{
    public class CreateWeatherRequest
    {
        public string Name { get; set; }
        public float Temperature { get; set; }
        public string Description { get; set; }
    }
    
    public class CreateWeatherRequestValidator : AbstractValidator<CreateWeatherRequest>
    {
        public CreateWeatherRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Temperature).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();

        }
    }
}