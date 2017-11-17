using System;

namespace Darker
{
    public interface IDateService
    {
        DateTime CurrentDate { get; }
        DateTime CurrentTime { get; }
    }
}
