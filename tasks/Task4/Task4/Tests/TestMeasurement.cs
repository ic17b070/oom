using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4.Tests
{
    [TestFixture]
    class TestMeasurement
    {
        [Test]
        public void CanCreateMeasurement()
        {
            var x = new Measurement(1, Unit.KILOGRAMM);
            Assert.IsTrue(x.Amount.Equals(1));
            Assert.IsTrue(x.Unit.Equals(Unit.KILOGRAMM));
        }

        [Test]
        public void CannotCreatePriceUnderZero()
        {
            Assert.Catch(() =>
            {
                var x = new Measurement(-1, Unit.KILOGRAMM);
            });
        }
    }
}
