using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4.Tests
{
    [TestFixture]
    class TestMeatProducts
    {
        [Test]
        public void CanCreateMeatProduct()
        {
            var x = new MeatProduct("Minced Meat", new Price(8.70m, Currency.EUR), new Measurement(1, Unit.KILOGRAMM), new DateTime(2018, 04, 01));
            Assert.IsTrue(x.Label.Equals("Minced Meat"));
            Assert.IsTrue(x.Price.Amount.Equals(8.70m));
            Assert.IsTrue(x.Price.Currency.Equals(Currency.EUR));
            Assert.IsTrue(x.Measurement.Amount.Equals(1));
            Assert.IsTrue(x.Measurement.Unit.Equals(Unit.KILOGRAMM));
            Assert.IsTrue(x.ExpirationDate.Year.Equals(2018));
            Assert.IsTrue(x.ExpirationDate.Month.Equals(04));
            Assert.IsTrue(x.ExpirationDate.Day.Equals(01));
        }

        [Test]
        public void CannotSetEmptyLabel()
        {
            Assert.Catch(() =>
            {
                var x = new MeatProduct("", new Price(1.20m, Currency.EUR), new Measurement(1, Unit.LITER), new DateTime(2018, 04, 03));
            });

            Assert.Catch(() =>
            {
                var x = new MeatProduct(null, new Price(1.20m, Currency.EUR), new Measurement(1, Unit.LITER), new DateTime(2018, 04, 03));
            });
        }

        [Test]
        public void CannotSetEmptyPrice()
        {
            Assert.Catch(() =>
            {
                var x = new MeatProduct("Minced Meat", null, new Measurement(1, Unit.KILOGRAMM), new DateTime(2018, 04, 01));
            });
        }

        [Test]
        public void TestExpiryCheck()
        {
            DateTime today, yesterday, tomorrow;
            today = DateTime.Today;
            yesterday = DateTime.Today.AddDays(-1);
            tomorrow = DateTime.Today.AddDays(1);

            var x = new MeatProduct("Minced Meat", new Price(8.70m, Currency.EUR), new Measurement(1, Unit.KILOGRAMM), today);
            Assert.IsTrue(x.HasExpired() == false);


            x = new MeatProduct("Minced Meat", new Price(8.70m, Currency.EUR), new Measurement(1, Unit.KILOGRAMM), yesterday);
            Assert.IsTrue(x.HasExpired() == true);


            x = new MeatProduct("Minced Meat", new Price(8.70m, Currency.EUR), new Measurement(1, Unit.KILOGRAMM), tomorrow);
            Assert.IsTrue(x.HasExpired() == false);
        }
    }
}
