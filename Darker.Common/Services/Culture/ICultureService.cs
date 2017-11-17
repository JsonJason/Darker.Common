using System.Globalization;

namespace Darker
{
    public interface ICultureService
    {
        CultureInfo CurrentCulture { get; }
    }
}