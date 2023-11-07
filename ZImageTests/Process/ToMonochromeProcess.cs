using PZWrapper.Types;
using ZImageTests.Types.Elementary;

namespace ZImageTests.Process
{
    public class ToMonochromeProcess : ABwProcess
    {
        public override string ProcessName => GetType().Name;
        public override ProcessResult<BWImage> Process(BWImage tIn)
        {
            throw new System.NotImplementedException();
        }
    }



}
