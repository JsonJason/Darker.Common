using System.Globalization;

namespace Darker.Common
{
    public class CultureService : ICultureService
    {
        private static CultureService _instance;

        public static CultureService Instance => _instance ?? (_instance = new CultureService());
        public CultureInfo CurrentCulture => CultureInfo.CurrentCulture;
    }
}