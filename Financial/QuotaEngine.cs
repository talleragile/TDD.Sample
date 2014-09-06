using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Financial
{
    public class QuotaEngine
    {
        public Quota GetQuota(double capital, double rate, int quotaNumber)
        {
            var quota = new Quota {Capital = capital/quotaNumber};
            quota.RateAmount = quota.Capital * rate;
            return quota;
        }
    }
}
