using System.Globalization;

namespace Darker
{
    /// <summary>
    ///     Providers the current Culture settings
    /// </summary>
    public interface ICultureService
    {
        /// <summary>
        ///     Returns the current culture
        /// </summary>
        CultureInfo CurrentCulture { get; }
    }
}