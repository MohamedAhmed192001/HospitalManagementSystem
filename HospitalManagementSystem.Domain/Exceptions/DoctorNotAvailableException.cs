using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.Exceptions
{
    public class DoctorNotAvailableException: DomainException
    {
        public DoctorNotAvailableException(int id)
            : base($"Doctor with Id $'{id}' is not available")
        { 
        }
    }
}
