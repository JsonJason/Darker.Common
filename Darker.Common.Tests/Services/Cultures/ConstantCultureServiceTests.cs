using System.Globalization;
using NUnit.Framework;

namespace Darker.Common.Tests
{
    [TestFixture]
    public class ConstantCultureServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _culture = new CultureInfo("fr-CA");
            _alternateCulture = new CultureInfo("sa-IN");
            _service = new ConstantCultureService(_culture);
        }

        private ConstantCultureService _service;
        private CultureInfo _culture;
        private CultureInfo _alternateCulture;

        [Test]
        public void CultureMatchesConstructor()
        {
            Assert.AreEqual(_culture, _service.CurrentCulture);
        }

        [Test]
        public void CurrentCulturePropertyChangesCurrentCulture()
        {
            _service.CurrentCulture = _alternateCulture;
            Assert.AreEqual(_alternateCulture, _service.CurrentCulture);
        }
    }
}