using System;

namespace Darker
{
    /// <summary>
    /// Date provider service
    /// </summary>
    public interface IDateService
    {
        /// <summary>
        /// Returns the current date
        /// <remarks>Ignore the time parameters of the datetime and use <see cref="CurrentTime"/> for time values</remarks>
        /// </summary>
        DateTime CurrentDate { get; }
        /// <summary>
        /// Returns the current time
        /// <remarks>Ignore the date parameters of the datetime and use <see cref="CurrentDate"/> for time values</remarks>
        /// </summary>
        DateTime CurrentTime { get; }
    }
}