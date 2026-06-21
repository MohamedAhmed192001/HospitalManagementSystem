using HospitalManagementSystem.Domain.Enums;
using MediatR;


namespace HospitalManagementSystem.Application.Doctors.Commands.UpdateDoctor
{
    public record UpdateDoctorCommand: IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string PhoneNumber { get; init; } = null!;    
        public DoctorSpecialization Specialization { get; init; }
    }
}
