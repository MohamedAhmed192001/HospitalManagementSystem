using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.Events
{
    public sealed class PatientRegisteredEvent: BaseEvent
    {
        public Patient Patient { get; set; }

        public PatientRegisteredEvent(Patient patient)
        {
            Patient = patient;
        }
    }
}
