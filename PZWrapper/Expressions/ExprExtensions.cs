using PZWrapper.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper.Expressions
{
    public static class ExprExtensions
    {
        public static void Test()
        {
            Emitter e = new Emitter();
            var expr = e.Mul(2, e.Add(4, e.Val()));// * 2 + 4 x; 
            var polish = expr.ToPolish();
            var polStr = polish.PolishToStr();
            Console.WriteLine(polStr);

            var exprRes = CppMethods.CreateExpression(polish.Count, polish.Select(p => p.OpType).ToArray(), polish.Select(p => p.DoubleValue).ToArray(), polish.Select(p => p.OperatorNo).ToArray());

            Console.WriteLine($"ExpRes from CPP is: {exprRes}");
            Console.ReadLine();
        }

        
        public static string PolishToStr(this List<OpInfo> opInfos) => string.Join(" ", opInfos);


        public static Num Num(this Emitter e, double val) => new Num() { Value = val };


        public static Val Val(this Emitter e) => new Val();



        public static string OperToStr(this OperatorNo opNo)
        {
            string res = opNo switch
            {
                OperatorNo.Add => "+",
                OperatorNo.Sub => "-",
                OperatorNo.Mul => "*",
                OperatorNo.Div => "/",
                _ => " not managed yet "
            };
            return res;
        }

        public static AExpression Mul(this Emitter e, AExpression op1, AExpression op2) => new Mult() { Operand1 = op1, Operand2 = op2 };
        public static AExpression Div(this Emitter e, AExpression op1, AExpression op2) => new Div() { Operand1 = op1, Operand2 = op2 };
        public static AExpression Add(this Emitter e, AExpression op1, AExpression op2) => new Plus() { Operand1 = op1, Operand2 = op2 };
        public static AExpression Sub(this Emitter e, AExpression op1, AExpression op2) => new Minus() { Operand1 = op1, Operand2 = op2 };


    }
}
