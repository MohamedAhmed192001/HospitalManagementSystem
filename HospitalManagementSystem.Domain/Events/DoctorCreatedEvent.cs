using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.Events
{
    public sealed class DoctorCreatedEvent: BaseEvent
    {
        public Doctor Doctor { get; set; }

        public DoctorCreatedEvent(Doctor doctor)
        {
            Doctor = doctor;
        }
    }
}
