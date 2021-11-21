using System;

namespace BLL
{
    public struct WorkTime
    {
        /// <summary>
        /// Start and End are expressed in hours
        /// </summary>

        public int start;
        public int end;
        public DayOfWeek[] days;

        public WorkTime(int start, int end, DayOfWeek[] days)
        {
            this.start = start;
            this.end = end;
            this.days = days;
        }
    }
}
