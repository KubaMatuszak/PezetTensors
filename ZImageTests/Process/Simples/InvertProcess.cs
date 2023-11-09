using PZWrapper.Types;
using PZWrapper.Extensions;
using ZImageTests.Types.Elementary;
using ZImageTests.Process.Generics;
using PZWrapper.Links;
using PZWrapper.Extensions;
namespace ZImageTests.Process.Simples
{
    public class InvertProcess : ABwProcess
    {
        public override string ProcessName => GetType().Name;

        public override ProcessResult<Matrix2D> Process(Matrix2D inputMatrix)
        {
            ProcessResult<Matrix2D> result = new ProcessResult<Matrix2D>();
            result.IsOk = true;
            result.ResBwIm = inputMatrix;
            return result;
        }
    }



}
