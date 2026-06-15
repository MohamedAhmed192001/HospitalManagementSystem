using FluentValidation;
using System.Security.Cryptography.X509Certificates;


namespace HospitalManagementSystem.Application.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorValidator: AbstractValidator<CreateDoctorCommand>
    {
        public CreateDoctorValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required")
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required")
                .MaximumLength(50);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required")
                .Matches(@"^\+?[0-9]{10,15}$")
                .WithMessage("Invalid phone number format");

            RuleFor(x => x.Specialization)
                .IsInEnum()
                .WithMessage("Invalid specialization");
        
        }
    }
}
