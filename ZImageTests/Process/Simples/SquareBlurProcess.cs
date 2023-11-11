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

namespace ZImageTests.Process.Simples
{
    public class SquareBlurProcess : AProcess<Matrix2D>
    {
        public override string ProcessName => GetType().Name;

        public override ProcessResult<Matrix2D> Process(Matrix2D matrix)
        {
            var blurIm = Marshaled.SquareBlur(matrix, 10);
            ProcessResult<Matrix2D> result = new ProcessResult<Matrix2D>();
            result.IsOk = true;
            result.ResBwIm = blurIm;
            return result;
        }
    }

}
