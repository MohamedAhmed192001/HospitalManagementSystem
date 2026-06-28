using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.ValueObjects
{
    public class TimeRange : ValueObject
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public int DurationInMinutes => 
            (int)(EndTime - StartTime).TotalMinutes;


        private TimeRange()
        {
            
        }

        public TimeRange(TimeOnly startTime, TimeOnly endTime)
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