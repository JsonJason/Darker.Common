using System;

namespace Darker
{
    public class UtcDateService : IDateService
    {
        private static UtcDateService _instance;

        private UtcDateService()
        {
        }

        public static UtcDateService Instance => _instance ?? (_instance = new UtcDateService());

        public DateTime CurrentDate => DateTime.UtcNow;

        public DateTime CurrentTime => DateTime.UtcNow;
    }
}