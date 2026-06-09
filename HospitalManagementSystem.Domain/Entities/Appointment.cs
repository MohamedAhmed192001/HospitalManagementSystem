using HospitalManagementSystem.Domain.Common;
using HospitalManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.Entities
{
    public class Appointment: BaseAuditableEntity
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public DateTime AppointmentDate { get; set; }

        public AppointmentStatus Status { get; set; } =
            AppointmentStatus.Pending;

        public string? Notes { get; set; } = string.Empty;

    }
}
