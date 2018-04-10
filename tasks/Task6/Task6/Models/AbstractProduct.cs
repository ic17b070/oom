using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public abstract class AbstractProduct : IProduct
    {
        public string Label { get; protected set; }
        public Measurement Measurement { get; protected set; }
        public Price Price { get; protected set; }
        public DateTime ExpirationDate { get; }

        public AbstractProduct(string label, Price price, Measurement measurement, DateTime expirationDate)
        {
            if (label == null || label.Equals(""))
                throw new ArgumentException("Please enter a label for this Item");
            if (price == null)
                throw new ArgumentException("Please enter a price for this Item");
            if (measurement == null)
                throw new ArgumentException("Please enter a measurement for this Item");
            if (expirationDate == null)
                throw new ArgumentException("Please enter an expiration date for this Item");

            Label = label;
            Price = price;
            Measurement = measurement;
            ExpirationDate = expirationDate;
        }

        public bool HasExpired()
        {
            DateTime today = DateTime.Today;
            var x = (DateComparisonResult)ExpirationDate.CompareTo(today);
            return ((DateComparisonResult)ExpirationDate.CompareTo(today) == DateComparisonResult.Earlier ) ? true : false;
        }

        public override string ToString()
        {
            return Label;
        }

        private enum DateComparisonResult
        {
            Earlier = -1,
            Later = 1,
            TheSame = 0
        };
    }
}
