using PZWrapper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZImageTests.Process;

namespace ZImageTests.Types.Elementary
{
    public abstract class AProcessable<Tin> : AChainable<AProcessable<Tin>>
    {
        public abstract ProcessResult<Tin> Process(Tin tIn);
        public ProcessResult<Tin> ProcessAll(Tin bWImage)
        {
            var res = this.Process(bWImage);
            if (Next != null)
                res = this.Process(res.ResBwIm);
            return res;
        }
    }



    public abstract class ABwProcess : AProcessable<BWImage>
    {
        public abstract string ProcessName { get; }
    }


    public abstract class AChainable<TBase> where TBase : AChainable<TBase>
    {
        public AChainable<TBase> Next { get; set; }
        public AChainable<TBase> Prev { get; set; }
        public AChainable<TBase> Root =>  Prev != null? Prev.Root: this;
        public AChainable<TBase> SetNext(AChainable<TBase> next)
        {
            Next = next;
            next.Prev = this;
            return next;
        }
    }

}
