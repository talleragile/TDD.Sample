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
        private QuotaEngine quotaEngine;
        [SetUp]
        public void Setup()
        {
            quotaEngine = new QuotaEngine();
        }
        [Test]
        [TestCase(1000,0.1,10,100,10,110)]
        [TestCase(600, 0.01, 10, 60, 0.6, 60.6)]
        [TestCase(5000, 0.1, 10, 500, 50, 550)]
        public void GetQuota_Test(double capital, double rate, int term, double capitalExpected, double rateAmmountExpected, double totalExpected )
        {
            
            var quota = quotaEngine.GetQuota(capital, rate, term);
            quota.Should().BeOfType<Quota>();
            quota.Capital.Should().Be(capitalExpected);
            quota.RateAmount.Should().Be(rateAmmountExpected);
            quota.Total.Should().Be(totalExpected);
        }
    }
}