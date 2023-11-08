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
    internal class SquareBlurProcess : ABwProcess
    {
        public override string ProcessName => GetType().Name;

        public override ProcessResult<Matrix2D> Process(Matrix2D bWImage)
        {
            var matrix = bWImage.ToMatrix2D();
            var blur = Marshaled.SquareBlur(bWImage, 10);
            Matrix2D blurIm = new Matrix2D(blur);
            ProcessResult<Matrix2D> result = new ProcessResult<Matrix2D>();
            result.IsOk = true;
            result.ResBwIm = blurIm;
            return result;
        }
    }
}
