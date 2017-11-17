using System;
using NUnit.Framework;

namespace Darker.Common.Tests.Services.Dates
{
    [TestFixture]
    internal class UtcDateServiceTests
    {
        private UtcDateService _service;

        [SetUp]
        public void SetUp()
        {
            _service = UtcDateService.Instance;
        }

        [Test]
        public void SingletonIsSameInstance()
        {
            Assert.AreEqual(UtcDateService.Instance,_service);
        }

        [Test]
        public void CurrentDateIsUtcNow()
        {
            Assert.AreEqual(DateTime.UtcNow, _service.CurrentDate);
        }

        [Test]
        public void CurrentTimeIsUtcNow()
        {
            var difference = DateTime.UtcNow - _service.CurrentTime;
            Assert.IsTrue(difference.Seconds < 10);
        }

    }
}