using FluentValidation;
using InsuranceAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAPI.Application.Validators
{
    public class InsuredValidator : AbstractValidator<InsuredDTO>
    {
        public InsuredValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.DateOfBirth).LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");
            RuleFor(x => x.PersonalNumber).NotEmpty().Length(11);
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
