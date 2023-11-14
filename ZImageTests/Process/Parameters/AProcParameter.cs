using System;

namespace ZImageTests.Process.Parameters
{

    public abstract class AGeneralParam
    {

    }

    public abstract class AProcParameter<T> : AGeneralParam
    {
        protected T _value;
        protected T _min;
        protected T _max;
        public abstract T CurrValue { get; set; }
        public T Min { get => _min; set => _min = value; }
        public T Max { get => _max; set => _max = value; }
    }





}
