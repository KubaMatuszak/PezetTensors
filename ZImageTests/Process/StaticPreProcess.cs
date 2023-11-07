using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZImageTests.Process.Aggregators;

namespace ZImageTests.Process
{
    public static class StaticPreProcess
    {
        private static BWProcessAggregator _aggregator;
        public static BWProcessAggregator Aggregator
        {
            get
            {
                if (_aggregator != null) 
                    return _aggregator;
                _aggregator = new BWProcessAggregator();
                ExposureCompensation exposure = new ExposureCompensation();
                _aggregator.Append(exposure);
                InvertProcess invert = new InvertProcess();
                _aggregator.Append(invert);
                return _aggregator;
            }
        }
    }
}
