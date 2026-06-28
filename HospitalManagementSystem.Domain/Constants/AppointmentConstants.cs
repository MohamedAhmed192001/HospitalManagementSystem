using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.Constants
{
    public static class AppointmentConstants
    {
        public const int DefaultDurationInMinutes = 30;
        public const int MinDurationInMinutes = 15;
        public const int MaxDurationInMinutes = 120;
        public const int MaxAppointmentsPerDoctorPerDay = 20;
        public const int MaxAppointmentsPerPatientPerDay = 3;
    }
}
