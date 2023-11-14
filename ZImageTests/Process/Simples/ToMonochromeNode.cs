using PZWrapper.Types;
using System.Collections.Generic;
using ZImageTests.Process.Generics;
using ZImageTests.Process.Parameters;
using ZImageTests.Types.Elementary;

namespace ZImageTests.Process.Simples
{
    public class ToMonochromeNode : ANode<Matrix2D>
    {
        public ToMonochromeNode() { IsBypassed = true; }
        //public override string ProcessName => GetType().Name;
        public override List<AGeneralParam> Parameters => new List<AGeneralParam>() { };
        public override ProcessResult<Matrix2D> Process(Matrix2D tIn)
        {
            return new ProcessResult<Matrix2D>() { ResBwIm = tIn, IsOk = true };
        }
    }



}
