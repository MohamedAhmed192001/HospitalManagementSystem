using HospitalManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Doctor> Doctors { get; }
        DbSet<Patient> Patients { get; }
        DbSet<Appointment> Appointments { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
