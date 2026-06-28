

namespace HospitalManagementSystem.Domain.Exceptions
{
    public class PatientAlreadyExistsException: DomainException
    {
        public PatientAlreadyExistsException(string nationalId)
            : base($"Patient with National Id '{nationalId}' already exists.")
        {
            
        }
    }
}
