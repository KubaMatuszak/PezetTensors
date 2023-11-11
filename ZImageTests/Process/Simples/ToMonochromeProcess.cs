using PZWrapper.Types;
using ZImageTests.Process.Generics;
using ZImageTests.Types.Elementary;

namespace ZImageTests.Process.Simples
{
    public class ToMonochromeProcess : AProcess<Matrix2D>
    {
        public override string ProcessName => GetType().Name;
        public override ProcessResult<Matrix2D> Process(Matrix2D tIn)
        {
            throw new System.NotImplementedException();
        }
    }



}
