using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.Exceptions
{
    public class DoctorAlreadyExistsException : DomainException
    {
        public DoctorAlreadyExistsException(string email): 
            base($"Doctor with email '{email}' already exists.")
        { 
        }
    }
}
