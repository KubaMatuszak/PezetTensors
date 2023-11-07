using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper.Expressions
{



    public abstract class AExpression
    {
        public abstract OperatorNo OperatorNo {get;}
        public abstract int NoOfArgs { get; }
        public abstract List<AExpression> Children { get; }

        public static implicit operator AExpression(double val) => new Num() { Value = val };
        public abstract List<OpInfo> ToPolish();

    }



    /// <summary>
    /// Class represents placeholder for input value
    /// </summary>
    public class Val : AExpression
    {
        public override OperatorNo OperatorNo => OperatorNo.None;
        public override int NoOfArgs => 1;

        public override List<AExpression> Children => new List<AExpression>() { };

        public override List<OpInfo> ToPolish() => new List<OpInfo>() { new OpInfo() { OpType = OpType.Val } };
    }

    public class Num : AExpression
    {
        public double Value { get; set; }
        public override OperatorNo OperatorNo => OperatorNo.None;
        public override int NoOfArgs => 1;
        public override List<AExpression> Children => new List<AExpression>() { };
        public override List<OpInfo> ToPolish() => new List<OpInfo>() { new OpInfo() { OpType = OpType.Num, DoubleValue = Value } };
    }

    public abstract class AUnaryExp : AExpression
    {
        public AExpression Operand1 { get; set; }
        public override int NoOfArgs => 1;
        public override List<AExpression> Children => new List<AExpression>() { Operand1 };
    }
    
    public class StartExpr : AExpression
    {
        public override int NoOfArgs => 0;

        public override OperatorNo OperatorNo => OperatorNo.None;

        public override List<AExpression> Children => new List<AExpression>() { };
        public override List<OpInfo> ToPolish() => new List<OpInfo>() { new OpInfo() { OpType = OpType.Start } };
    }




    public abstract class ABinaryExp : AExpression
    {
        public AExpression Operand1 { get; set; }
        public AExpression Operand2 { get; set; }
        public override List<AExpression> Children => new List<AExpression>() { Operand1, Operand2 };
        public override int NoOfArgs => 2;
        public override List<OpInfo> ToPolish() 
        {
            var list = new List<OpInfo>();
            list.Add(new OpInfo() { OpType = OpType.Operator, OperatorNo = OperatorNo });
            list.AddRange(Operand1.ToPolish());
            list.AddRange(Operand2.ToPolish());
            return list;
        }
    }


    public class Plus : ABinaryExp
    {
        public override OperatorNo OperatorNo => OperatorNo.Add;
    }

    public class Minus : ABinaryExp
    {
        public override OperatorNo OperatorNo => OperatorNo.Sub;
    }

    public class Mult : ABinaryExp
    {
        public override OperatorNo OperatorNo => OperatorNo.Mul;
    }

    public class Div : ABinaryExp
    {
        public override OperatorNo OperatorNo => OperatorNo.Div;
    }



}
