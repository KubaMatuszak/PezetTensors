using PZWrapper.Types;
using ZImageTests.Process.Generics;
using ZImageTests.Types.Elementary;
using PZWrapper.Links;
using System.Collections.Generic;
using ZImageTests.Process.Parameters;

namespace ZImageTests.Process.Simples
{
    public class SampleBlurNode : ANode<Matrix2D>
    {
        public SampleBlurNode() { IsBypassed = true; }

        public override List<AGeneralParam> Parameters => new List<AGeneralParam>() { RadiusParam };

        // public override string ProcessName => GetType().Name;
        public override ProcessResult<Matrix2D> Process(Matrix2D inputMatrix)
        {
            var blurIm = Marshaled.SampleBlur(inputMatrix);
            ProcessResult<Matrix2D> result = new ProcessResult<Matrix2D>();
            result.IsOk = true;
            result.ResBwIm = blurIm;
            return result;
        }

        public DoubleParam RadiusParam = new DoubleParam() { CurrValue = 3, Min = 0, Max = 50 };

    }

}
