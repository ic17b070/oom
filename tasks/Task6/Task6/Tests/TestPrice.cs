using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task6.Tests
{
    [TestFixture]
    class TestPrice
    {
        [Test]
        public void CanCreatePrice()
        {
            var x = new Price(1, Currency.EUR);
            Assert.IsTrue(x.Amount.Equals(1));
            Assert.IsTrue(x.Currency.Equals(Currency.EUR));
        }

        [Test]
        public void CannotCreatePriceUnderZero()
        {
            Assert.Catch(() =>
            {
                var x = new Price(-1, Currency.EUR);
            });
        }
    }
}
