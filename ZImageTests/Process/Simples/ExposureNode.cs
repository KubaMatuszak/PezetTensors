using PZWrapper.Types;
using System.Collections.Generic;
using ZImageTests.Process.Generics;
using ZImageTests.Process.Parameters;
using ZImageTests.Types.Elementary;

namespace ZImageTests.Process.Simples
{
    public class ExposureNode : ANode<Matrix2D>
    {
        public ExposureNode() { IsBypassed = true; }
        public override List<AGeneralParam> Parameters => new List<AGeneralParam> { ExposureParam };

        //public override string ProcessName => GetType().Name;
        public override ProcessResult<Matrix2D> Process(Matrix2D tIn) => new ProcessResult<Matrix2D>() { ResBwIm = tIn, IsOk = true };

        public DoubleParam ExposureParam = new DoubleParam() { CurrValue = 2, Min = 0.25, Max = 4 };

    }



}
