using PZWrapper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZImageTests.Process.Aggregators;
using ZImageTests.Process.Simples;
using ZImageTests.Types.Elementary;

namespace ZImageTests.Process
{
    public static class StaticPreProcess
    {
        private static BWLinearProcessAggregator _aggregator;


        /// <summary>
        /// Sample aggregator (Exposure + invert)
        /// </summary>
        public static BWLinearProcessAggregator SampleAggregator
        {
            get
            {
                if (_aggregator != null) 
                    return _aggregator;
                _aggregator = new BWLinearProcessAggregator();
                //ExposureCompensation exposure = new ExposureCompensation();
                //_aggregator.Append(exposure);

                //InvertProcess invert = new InvertProcess();
                //_aggregator.Append(invert);

                _aggregator.Append(new CroppCutNode());
                _aggregator.Append(new SampleBlurNode());
                return _aggregator;
            }
        }
    }
}
