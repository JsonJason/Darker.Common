using System;

namespace Darker
{
    /// <summary>
    ///     A <see cref="Darker.IDateService" /> that provides the standard <see cref="DateTime" /> UtcNow
    /// </summary>
    public class UtcDateService : IDateService
    {
        private static UtcDateService _instance;

        private UtcDateService()
        {
        }

        /// <summary>
        ///     Singleton instance
        /// </summary>
        public static UtcDateService Instance => _instance ?? (_instance = new UtcDateService());

        public DateTime CurrentDate => DateTime.UtcNow;

        public DateTime CurrentTime => DateTime.UtcNow;
    }
}