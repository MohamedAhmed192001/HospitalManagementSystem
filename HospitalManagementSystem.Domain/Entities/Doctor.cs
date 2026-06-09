using HospitalManagementSystem.Domain.Common;
using HospitalManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.Entities
{
    public class Doctor : BaseAuditableEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DoctorSpecialization Specialization { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();   

    }
}
