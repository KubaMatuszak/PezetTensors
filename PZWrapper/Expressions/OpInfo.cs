namespace PZWrapper.Expressions
{
    public class OpInfo
    {
        public OpType OpType;
        public double DoubleValue;
        public OperatorNo OperatorNo;

        public override string ToString()
        {
            string res = OpType switch
            {
                OpType.Start => string.Empty,
                OpType.Val => "V",
                OpType.Num => $"{DoubleValue}",
                OpType.Operator => OperatorNo.OperToStr(),
                _ => " error "
            };

            return res;
        }
    }



}
