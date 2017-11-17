using System;
using System.Globalization;

namespace Darker.Common
{
    public class ConstantCultureService : ICultureService
    {
        private CultureInfo _currentCulture;

        public ConstantCultureService(CultureInfo culture)
        {
            CurrentCulture = culture;
        }

        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set => _currentCulture = value ?? throw new ArgumentNullException(nameof(CurrentCulture));
        }
    }
}