using PZWrapper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZImageTests.Process.Generics;
using ZImageTests.Types.Elementary;
using PZWrapper.Extensions;
using PZWrapper.Links;
using ZImageTests.Process.Parameters;

namespace ZImageTests.Process.Simples
{
    public class SquareBlurNode : ANode<Matrix2D>
    {
        public SquareBlurNode() { IsBypassed = true; }
        //public override string ProcessName => GetType().Name;
        public override List<AGeneralParam> Parameters => new List<AGeneralParam>() { RadiusParam };
        public override ProcessResult<Matrix2D> Process(Matrix2D matrix)
        {
            var blurIm = Marshaled.SquareBlur(matrix, 10);
            ProcessResult<Matrix2D> result = new ProcessResult<Matrix2D>();
            result.IsOk = true;
            result.ResBwIm = blurIm;
            return result;
        }

        public DoubleParam RadiusParam = new DoubleParam() { CurrValue = 3, Min = 0, Max = 50 };

    }

}
