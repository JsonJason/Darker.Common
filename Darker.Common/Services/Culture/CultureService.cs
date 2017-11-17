using System.Globalization;

namespace Darker
{
    public class CultureService : ICultureService
    {
        private static CultureService _instance;

        public static CultureService Instance => _instance ?? (_instance = new CultureService());
        public CultureInfo CurrentCulture => CultureInfo.CurrentCulture;
    }
}