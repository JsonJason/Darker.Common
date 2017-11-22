using System;

namespace Darker
{
    /// <summary>
    ///     A wrapper for a manually provided date and time for a <see cref="Darker.IDateService" />
    /// </summary>
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