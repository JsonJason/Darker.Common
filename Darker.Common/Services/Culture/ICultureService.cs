using System.Globalization;

namespace Darker.Common
{
    public interface ICultureService
    {
        CultureInfo CurrentCulture { get; }
    }
}