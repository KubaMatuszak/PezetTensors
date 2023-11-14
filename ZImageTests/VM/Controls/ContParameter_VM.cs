using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PZWrapper.Extensions;
using ZImageTests.Process.Parameters;

namespace ZImageTests.VM.Controls
{
    public class ContParameter_VM : AParameter_VM
    {
        public ContParameter_VM() { }
        public ContParameter_VM(DoubleParam doubleParam)
        {
            Value = doubleParam.CurrValue;
            Min = doubleParam.Min; 
            Max = doubleParam.Max;
        }

        public ContParameter_VM(IntParam? ip)
        {
            Value = ip.CurrValue;
            Min = ip.Min;
            Max = ip.Max;
        }

        private double _value;
        private double _min = 0.25;
        private double _max = 4;
        public double Value { get { return _value; } set { _value = value.Clip(_min, _max); SetProperty(ref _value, value); } }
        public double Min { get { return _min; } set { SetProperty(ref _min, value); } }
        public double Max { get { return _max; } set { SetProperty(ref _max, value); } }
    }
}
