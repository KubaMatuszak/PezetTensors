using PZWrapper.Types;
using ZImageTests.Process.Generics;
using ZImageTests.Types.Elementary;

namespace ZImageTests.Process.Simples
{
    public class ExposureCompensation : ABwProcess
    {
        public override string ProcessName => GetType().Name;
        public override ProcessResult<Matrix2D> Process(Matrix2D tIn) => new ProcessResult<Matrix2D>() { ResBwIm = tIn, IsOk = true };
    }



}
