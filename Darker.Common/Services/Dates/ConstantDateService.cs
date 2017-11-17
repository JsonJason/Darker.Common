using System;

namespace Darker.Common
{
    public class ConstantDateService : IDateService
    {
        public ConstantDateService(DateTime date, DateTime time)
        {
            CurrentDate = date;
            CurrentTime = time;
        }

        public DateTime CurrentDate { get; set; }

        public DateTime CurrentTime { get; set; }
    }
}