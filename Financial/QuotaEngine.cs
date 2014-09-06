using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Financial
{
    public class QuotaEngine
    {
        private double _capital;
        private double _rate;
        private int _term;

        public QuotaEngine(double capital, double rate, int term)
        {
            // TODO: Complete member initialization
            this._capital = capital;
            this._rate = rate;
            this._term = term;
        }
        public Quota GetQuota()
        {
            var quota = new Quota {Capital = _capital/_term};
            quota.RateAmount = quota.Capital * _rate;
            return quota;
        }

        public IList<Quota> GetPaymentCalendar()
        {
            throw new NotImplementedException();
        }
    }
}
