using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.Exceptions
{
    public class AppointmentLimitExceededException: DomainException
    {
        public AppointmentLimitExceededException()
            :base("Doctor has reached the maximum number of appointments for today.")
        {
            
        }
    }
}
