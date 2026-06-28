using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.ValueObjects
{
    public class WorkingHours : ValueObject
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public bool IsWithinWorkingHours(TimeOnly time)
        {
            return time >= StartTime && time <= EndTime;
        }

        public WorkingHours(TimeOnly startTime, TimeOnly endTime)
        {
            if(endTime <= startTime)
            {
                throw new ArgumentException("End time must be greater than Start time");
            }

            StartTime = startTime;
            EndTime = endTime;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StartTime;
            yield return EndTime;
        }
    }
}
