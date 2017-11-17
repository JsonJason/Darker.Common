using System;

namespace Darker.Common
{
    public interface IDateService
    {
        DateTime CurrentDate { get; }
        DateTime CurrentTime { get; }
    }
}
