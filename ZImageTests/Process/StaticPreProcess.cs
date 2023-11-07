using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZImageTests.Process
{
    public static class StaticPreProcess
    {
        private static ProcessAggregator _aggregator;
        public static ProcessAggregator Aggregator
        {
            get
            {
                if (_aggregator != null) 
                    return _aggregator;
                _aggregator = new ProcessAggregator();
                ExposureCompensation exposure = new ExposureCompensation();
                _aggregator.Append(exposure);
                InvertProcess invert = new InvertProcess();
                _aggregator.Append(invert);
                return _aggregator;
            }
        }
    }
}
