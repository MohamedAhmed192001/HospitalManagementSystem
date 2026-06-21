using Ardalis.GuardClauses;
using HospitalManagementSystem.Application.Common.Interfaces;
using MediatR;


namespace HospitalManagementSystem.Application.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorHandler : IRequestHandler<UpdateDoctorCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateDoctorHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _context.Doctors.FindAsync(new object[] { request.Id }, cancellationToken);
            Guard.Against.Null(doctor, nameof(doctor), $"Doctor with Id {request.Id} not found.");

            doctor.FirstName = request.FirstName;
            doctor.LastName = request.LastName;
            doctor.Email = request.Email;
            doctor.PhoneNumber = request.PhoneNumber;
            doctor.Specialization = request.Specialization;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
