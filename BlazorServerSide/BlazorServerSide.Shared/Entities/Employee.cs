using Dapper.Contrib.Extensions;
using FluentValidation;
using System;

namespace BlazorServerSide.Shared.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        [Computed] public bool IsNew => Id == default;        
    }

    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .WithMessage("Please enter name")
                .MaximumLength(50)
                .WithMessage("Maximum of 50 characters allowed");

            RuleFor(p => p.LastName)
                .NotEmpty()
                .WithMessage("Please enter last name")
                .MaximumLength(50)
                .WithMessage("Maximum of 50 characters allowed");

            RuleFor(p => p.Department)
                .NotEmpty()
                .WithMessage("Please enter department")
                .MaximumLength(20)
                .WithMessage("Maximum of 20 characters allowed");
        }
    }
}
