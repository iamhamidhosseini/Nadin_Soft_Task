using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using task.Models;

namespace task.Validator
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.ProduceDate).NotEmpty().WithMessage("ProduceDate is required.");
            RuleFor(x => x.ManufacturePhone).Matches(@"^\d{10}$").WithMessage("ManufacturePhone must be a valid phone number.");
            RuleFor(x => x.ManufactureEmail).EmailAddress().WithMessage("Invalid email address.");
        }
    }
}
