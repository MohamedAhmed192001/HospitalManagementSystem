using HospitalManagementSystem.Application.Common.Interfaces;
using HospitalManagementSystem.Domain.Entities;
using MediatR;


namespace HospitalManagementSystem.Application.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorHandler : IRequestHandler<CreateDoctorCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateDoctorHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {

            if(_context.Doctors.Any(d => d.Email == request.Email))
            {
                throw new Exception ("A doctor with the same email already exists.");
            }

            var doctor = new Doctor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Specialization = request.Specialization
            };

            _context.Doctors.Add(doctor);

            await _context.SaveChangesAsync(cancellationToken);

            return doctor.Id;
        }
    }
}
