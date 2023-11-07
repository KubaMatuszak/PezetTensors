using PZWrapper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZImageTests.Process.Generics;

namespace ZImageTests.Types.Elementary
{
    public abstract class AChainable<TBase> where TBase : AChainable<TBase>
    {
        public TBase Next { get; set; }
        public TBase Prev { get; set; }
        public TBase Root => Prev != null ? Prev.Root : (this as TBase);
        public AChainable<TBase> SetNext(TBase next)
        {
            Next = next;
            next.Prev = (this as TBase);
            return next;
        }
    }



    public abstract class AProcess<Tin> : AChainable<AProcess<Tin>>
    {
        public abstract ProcessResult<Tin> Process(Tin tIn);
        public ProcessResult<Tin> ProcessAll(Tin bWImage)
        {
            var res = this.Process(bWImage);
            if (Next != null)
                res = this.Process(res.ResBwIm);
            return res;
        }
        public abstract string ProcessName { get; }
    }


    public abstract class ABwProcess : AProcess<BWImage>
    {
    }


}
