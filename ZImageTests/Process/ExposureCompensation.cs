using PZWrapper.Types;
using ZImageTests.Types.Elementary;

namespace ZImageTests.Process
{
    public class ExposureCompensation : ABwProcess
    {
        public override string ProcessName => GetType().Name;
        public override ProcessResult<BWImage> Process(BWImage tIn) => new ProcessResult<BWImage>() { ResBwIm = tIn, IsOk = true };
    }



}
