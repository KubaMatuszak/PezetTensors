namespace ZImageTests.Process.Parameters
{
    public class DoubleParam : AProcParameter<double>
    {
        public override double CurrValue { get => _value; set => _value = value ; } //< _min ? _min : value > _max ? _max : value
    }





}
