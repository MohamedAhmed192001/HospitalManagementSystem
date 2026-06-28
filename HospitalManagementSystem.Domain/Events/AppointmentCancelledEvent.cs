using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.Events
{
    public sealed class AppointmentCancelledEvent: BaseEvent
    {
        public Appointment Appointment { get; set; }
        public AppointmentCancelledEvent(Appointment appointment)
        {
            Appointment = appointment;
        }
    }
}
