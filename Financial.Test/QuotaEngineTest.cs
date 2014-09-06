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
        public void GetQuota_When_Capital_1000_and_Interes_10_Term_10_Return_101()
        {
            
            var quota = quotaEngine.GetQuota(1000, 0.10, 10);
            quota.Should().BeOfType<Quota>();
            quota.Capital.Should().Be(100);
            quota.RateAmount.Should().Be(10);
            quota.Total.Should().Be(110);
        }

        [Test]
        public void GetQuota_When_Capital_600_and_Interes_1_Term_10_Return_60dot6()
        {
            var quota = quotaEngine.GetQuota(600, 0.01, 10);
            quota.Should().BeOfType<Quota>();
            quota.Capital.Should().Be(60);
            quota.RateAmount.Should().Be(0.6);
            quota.Total.Should().Be(60.6);
        }

        [Test]
        public void GetQuota_When_Capital_5000_Rate_10_Term_10_Return_Quota_Capital_500_Rate_50()
        {
            var quota = quotaEngine.GetQuota(5000, 0.1, 10);
            quota.Capital.Should().Be(500);
            quota.RateAmount.Should().Be(50);
            quota.Total.Should().Be(550);
        }
    }
}