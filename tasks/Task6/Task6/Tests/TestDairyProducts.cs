using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task6.Tests
{
    [TestFixture]
    class TestDairyProducts
    {
        [Test]
        public void CanCreateDairyProduct()
        {
            var x = new DairyProduct("Milk", new Price(1.20m, Currency.EUR), new Measurement(1, Unit.LITER), new DateTime(2018, 04, 03));
            Assert.IsTrue(x.Label.Equals("Milk"));
            Assert.IsTrue(x.Price.Amount.Equals(1.20m));
            Assert.IsTrue(x.Price.Currency.Equals(Currency.EUR));
            Assert.IsTrue(x.Measurement.Amount.Equals(1));
            Assert.IsTrue(x.Measurement.Unit.Equals(Unit.LITER));
            Assert.IsTrue(x.ExpirationDate.Year.Equals(2018));
            Assert.IsTrue(x.ExpirationDate.Month.Equals(04));
            Assert.IsTrue(x.ExpirationDate.Day.Equals(03));
        }

        [Test]
        public void CannotSetEmptyLabel()
        {
            Assert.Catch(() =>
            {
                var x = new DairyProduct("", new Price(1.20m, Currency.EUR), new Measurement(1, Unit.LITER), new DateTime(2018, 04, 03));
            });

            Assert.Catch(() =>
            {
                var x = new DairyProduct(null, new Price(1.20m, Currency.EUR), new Measurement(1, Unit.LITER), new DateTime(2018, 04, 03));
            });
        }

        [Test]
        public void CannotSetEmptyPrice()
        {
            Assert.Catch(() =>
            {
                var x = new DairyProduct("Milk", null, new Measurement(1, Unit.LITER), new DateTime(2018, 04, 03));
            });
        }

        [Test]
        public void TestExpiryCheck()
        {
            DateTime today, yesterday, tomorrow;
            today = DateTime.Today;
            yesterday = DateTime.Today.AddDays(-1);
            tomorrow = DateTime.Today.AddDays(1);

            var x = new DairyProduct("Milk", new Price(1.20m, Currency.EUR), new Measurement(1, Unit.LITER), today);
            Assert.IsTrue(x.HasExpired() == false);


            x = new DairyProduct("Milk", new Price(1.20m, Currency.EUR), new Measurement(1, Unit.LITER), yesterday);
            Assert.IsTrue(x.HasExpired() == true);


             x = new DairyProduct("Milk", new Price(1.20m, Currency.EUR), new Measurement(1, Unit.LITER), tomorrow);
            Assert.IsTrue(x.HasExpired() == false);
        }

    }
}
