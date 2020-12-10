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
        public DateTime DateCreated { get; set; } = DateTime.UtcNow; // in a real app, we'd setup correct local times based on user profile
        [Computed] public bool IsNew => Id == default;        
    }

    /*
    I would normally use my ModelSync app to create this in target database
    http://www.aosoftware.net/modelSync.html
    but for that to work well, you need to put entity classes in a .NET Standard DLL.
    Unfortunately my app is pretty fussy here, so I just created this table manually

    CREATE TABLE [dbo].[Employee] (
	    [Id] int identity(1,1) NOT NULL PRIMARY KEY,
	    [FirstName] nvarchar(50) NOT NULL,
	    [LastName] nvarchar(50) NOT NULL,
	    [Department] nvarchar(50) NOT NULL,
	    [DateModified] datetime NULL,
	    [DateCreated] datetime NOT NULL
    )
    */

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
