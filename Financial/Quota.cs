using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Financial
{
    public class Quota
    {
        public double Capital { get; set; }
        public double RateAmount { get; set; }
        public double Total { get { return Capital + RateAmount; } }
    }
}
