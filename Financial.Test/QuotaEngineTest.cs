using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Financial;
using FluentAssertions;

namespace Financial.Test
{
    [TestFixture]
    public class QuotaEngineTest
    {
        [Test]
        [TestCase(1000, 0.1, 10, 100, 10, 110)]
        [TestCase(600, 0.01, 10, 60, 0.6, 60.6)]
        [TestCase(5000, 0.1, 10, 500, 50, 550)]
        public void GetQuota_Test(double capital, double rate, int term, double capitalExpected, double rateAmmountExpected, double totalExpected)
        {
            var quotaEngine = new QuotaEngine(capital, rate, term);
            var quota = quotaEngine.GetQuota();
            quota.Should().BeOfType<Quota>();
            quota.Capital.Should().Be(capitalExpected);
            quota.RateAmount.Should().Be(rateAmmountExpected);
            quota.Total.Should().Be(totalExpected);
        }

        [Test]
        public void GetCalendar_When_Capital_5000_Rate_10_Term_10_Return_Calendar_With_Ten_Quotas()
        {
            var loan = new QuotaEngine(5000, 0.1, 10);
            var calendar = loan.GetPaymentCalendar();
            calendar.Should().BeOfType<PaymentCalendar>();
            calendar.Quotes.Count.Should().Be(10);
        }

        [Test]
        public void GetCalendar_When_Capital_5000_Rate_10_Term_10_Return_Calendar_TotalRate_500()
        {
            var loan = new QuotaEngine(5000, 0.1, 10);
            var calendar = loan.GetPaymentCalendar();
            calendar.Should().BeOfType<PaymentCalendar>();
            calendar.Quotes.Should().BeOfType<List<Quota>>();
            calendar.Quotes.Count.Should().Be(10);
            calendar.TotalRate.Should().Be(500);

        }
    }
}