using System;
using NUnit.Framework;

namespace Darker.Common.Tests.Services.Dates
{
    [TestFixture]
    internal class ConstantDateServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _date = new DateTime(2017, 10, 10);
            _time = new DateTime(2017, 10, 10, 10, 10, 10);
            _service = new ConstantDateService(_date, _time);
        }

        private ConstantDateService _service;
        private DateTime _date, _time;

        [Test]
        public void DatePropertyChangesCurrentDate()
        {
            var newDate = new DateTime(2016, 5, 5);
            _service.CurrentDate = newDate;

            Assert.AreEqual(newDate, _service.CurrentDate);
        }

        [Test]
        public void DatesMatchConstructorArguments()
        {
            Assert.AreEqual(_date, _service.CurrentDate);
            Assert.AreEqual(_time, _service.CurrentTime);
        }

        [Test]
        public void TimePropertyChangesCurrentTime()
        {
            var newTime = new DateTime(2016, 5, 5, 5, 5, 5);
            _service.CurrentTime = newTime;

            Assert.AreEqual(newTime, _service.CurrentTime);
        }
    }
}