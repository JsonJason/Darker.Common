using System;
using NUnit.Framework;

namespace Darker.Common.Tests
{
    [TestFixture]
    internal class UtcDateServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _service = UtcDateService.Instance;
        }

        private UtcDateService _service;

        [Test]
        public void CurrentDateIsUtcNow()
        {
            var difference = DateTime.UtcNow - _service.CurrentDate;
            Assert.IsTrue(difference.Seconds < 10);
        }

        [Test]
        public void CurrentTimeIsUtcNow()
        {
            var difference = DateTime.UtcNow - _service.CurrentTime;
            Assert.IsTrue(difference.Seconds < 10);
        }

        [Test]
        public void SingletonIsSameInstance()
        {
            Assert.AreEqual(UtcDateService.Instance, _service);
        }
    }
}