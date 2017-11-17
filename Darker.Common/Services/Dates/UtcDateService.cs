using System;

namespace Darker.Common
{
    public class UtcDateService : IDateService
    {
        private static UtcDateService _instance;
        public static UtcDateService Instance => _instance ?? (_instance = new UtcDateService());

        public DateTime CurrentDate => DateTime.UtcNow;

        public DateTime CurrentTime => DateTime.UtcNow;

        private UtcDateService() { }
    }
}