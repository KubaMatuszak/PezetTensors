using PZWrapper.Types;
using PZWrapper.Extensions;
using ZImageTests.Types.Elementary;
using ZImageTests.Process.Generics;
using PZWrapper.Links;
using PZWrapper.Extensions;
using System.Collections.Generic;
using ZImageTests.Process.Parameters;

namespace ZImageTests.Process.Simples
{
    public class InvertNode : ANode<Matrix2D>
    {
        //public override string ProcessName => GetType().Name;
        public InvertNode() {IsBypassed = true;}
        public override List<AGeneralParam> Parameters => new List<AGeneralParam>() { };
        public override ProcessResult<Matrix2D> Process(Matrix2D inputMatrix)
        {
            ProcessResult<Matrix2D> result = new ProcessResult<Matrix2D>();
            result.IsOk = true;
            result.ResBwIm = inputMatrix;
            return result;
        }
    }



}
