using FluentValidation;
using InsuranceAPI.Application.DTOs;

public class InsuranceProductValidator : AbstractValidator<InsuranceProductDTO>
{
    public InsuranceProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required")
            .MaximumLength(100).WithMessage("Product name must not exceed 100 characters");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters");

        RuleFor(p => p.Premium)
            .GreaterThan(0).WithMessage("Premium must be greater than 0");

        RuleFor(p => p.CoverageAmount)
            .GreaterThan(0).WithMessage("Coverage amount must be greater than 0");

        RuleFor(p => p.StartDate)
            .LessThan(p => p.EndDate).WithMessage("Start date must be before end date");
    }
}
