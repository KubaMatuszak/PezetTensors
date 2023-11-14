namespace ZImageTests.Process.Parameters
{
    public class IntParam : AProcParameter<int>
    {
        public override int CurrValue { get => CurrValue; set => _value = value ; } //< _min ? _min : value > _max ? _max : value
    }





}
