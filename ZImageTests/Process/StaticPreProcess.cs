using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZImageTests.Process.Aggregators;
using ZImageTests.Process.Simples;

namespace ZImageTests.Process
{
    public static class StaticPreProcess
    {
        private static BWLinearCompoundProcess _aggregator;


        /// <summary>
        /// Sample aggregator (Exposure + invert)
        /// </summary>
        public static BWLinearCompoundProcess SampleAggregator
        {
            get
            {
                if (_aggregator != null) 
                    return _aggregator;
                _aggregator = new BWLinearCompoundProcess();
                //ExposureCompensation exposure = new ExposureCompensation();
                //_aggregator.Append(exposure);

                //InvertProcess invert = new InvertProcess();
                //_aggregator.Append(invert);

                SquareBlurProcess squareBlurProcess = new SquareBlurProcess();
                _aggregator.Append(squareBlurProcess);
                return _aggregator;
            }
        }
    }
}
