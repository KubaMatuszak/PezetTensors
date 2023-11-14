using PZWrapper.Types;
using ZImageTests.Process.Generics;
using ZImageTests.Types.Elementary;
using PZWrapper.Links;
using System.Collections.Generic;
using ZImageTests.Process.Parameters;

namespace ZImageTests.Process.Simples
{
    public class CroppCutNode : ANode<Matrix2D>
    {
        //public override string ProcessName => GetType().Name;
        public CroppCutNode() { IsBypassed = true; }

        public override List<AGeneralParam> Parameters => new List<AGeneralParam>() { LeftParam, TopParam, RightParam, BottomParam };

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

        public DoubleParam LeftParam = new DoubleParam() { CurrValue = 3, Min = 0.25, Max = 4 };
        public DoubleParam TopParam = new DoubleParam() { CurrValue = 4, Min = 0.25, Max = 4 };
        public DoubleParam RightParam = new DoubleParam() { CurrValue = 2, Min = 0.25, Max = 4 };
        public DoubleParam BottomParam = new DoubleParam() { CurrValue = 3, Min = 0.25, Max = 4 };
    }





}
