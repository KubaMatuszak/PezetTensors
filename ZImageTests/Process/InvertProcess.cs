using PZWrapper.Types;
using PZWrapper.Extensions;
using ZImageTests.Types.Elementary;
using ZImageTests.Process.Generics;

namespace ZImageTests.Process
{
    public class InvertProcess : ABwProcess
    {
        public override string ProcessName => GetType().Name;

        public override ProcessResult<BWImage> Process(BWImage bWImage)
        {
            var matrix = bWImage.ToMatrix2D();
            matrix.Inverse256();
            BWImage res = new BWImage(matrix);
            ProcessResult<BWImage> result = new ProcessResult<BWImage>();
            result.IsOk = true;
            result.ResBwIm = res;
            return result;
        }
    }



}
