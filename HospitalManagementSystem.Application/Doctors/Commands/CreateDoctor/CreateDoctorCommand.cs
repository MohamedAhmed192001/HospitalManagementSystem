using HospitalManagementSystem.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Doctors.Commands.CreateDoctor
{
    public record CreateDoctorCommand: IRequest<int>
    {
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string PhoneNumber { get; init; } = null!;
        public DoctorSpecialization Specialization { get; init; }
    }
}
