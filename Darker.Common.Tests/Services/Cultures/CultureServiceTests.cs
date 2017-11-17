using System.Globalization;
using NUnit.Framework;

namespace Darker.Common.Tests
{
    [TestFixture]
    public class CultureServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _service = CultureService.Instance;
        }

        private CultureService _service;

        [Test]
        public void CurrentCultureIsCurrentThreadCulture()
        {
            Assert.AreEqual(CultureInfo.CurrentCulture, _service.CurrentCulture);
        }

        [Test]
        public void SingletonIsSameInstance()
        {
            Assert.AreEqual(CultureService.Instance, _service);
        }
    }
}