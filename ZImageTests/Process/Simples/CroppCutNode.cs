using PZWrapper.Types;
using ZImageTests.Process.Generics;
using ZImageTests.Types.Elementary;
using PZWrapper.Links;
using System;

namespace ZImageTests.Process.Simples
{
    public class CroppCutNode : ANode<Matrix2D>
    {
        //public override string ProcessName => GetType().Name;
        public CroppCutNode() { IsBypassed = false; }




        public override ProcessResult<Matrix2D> Process(Matrix2D inputMatrix)
        {
            var left = 200;// (int)(0.80 * inputMatrix.NCols / 2);
            var right = 200;// left;
            var top = 200;// (int)(0.80 * inputMatrix.NRows / 2); ;
            var bottom = 200;// top;

            var blurIm = Marshaled.CroppCutMargin(inputMatrix, left, top, right, bottom);
            ProcessResult<Matrix2D> result = new ProcessResult<Matrix2D>();
            result.IsOk = true;
            result.ResBwIm = blurIm;
            return result;
        }
    }

    public abstract class AProcParameter<T> where T: IComparable<T>
    {
        protected T _value;
        protected T _min;
        protected T _max;
        public abstract T Value { get; set; } 
    }

    public class IntParam : AProcParameter<int>
    {
        public override int Value { get => Value; set =>  _value = Value < _min? _min: Value > _max? _max: Value ; }
    }

    public class DoubleParam : AProcParameter<double>
    {
        public override double Value { get => Value; set => _value = Value < _min ? _min : Value > _max ? _max : Value; }
    }





}
