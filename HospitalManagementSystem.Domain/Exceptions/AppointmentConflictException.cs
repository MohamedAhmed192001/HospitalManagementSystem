using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.Exceptions
{
    public class AppointmentConflictException: DomainException
    {
        public AppointmentConflictException()
            :base("Appointment time conflicts with an existing appointment.")
        {
        }
    }
}
