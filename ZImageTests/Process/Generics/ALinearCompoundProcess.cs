using System.Collections.Generic;
using System.Linq;
using ZImageTests.Types.Elementary;

namespace ZImageTests.Process.Generics
{
    public abstract class ALinearCompoundProcess<Tin>
    {
        public static void Test()
        {
            ALinearCompoundProcess<Tin> aProcessAggregator = null;
            var first = aProcessAggregator.ProcessList.First();
            //first.Next
        }
        protected ALinearCompoundProcess() { }
        public List<AProcess<Tin>> ProcessList = new List<AProcess<Tin>>();
        public void Append(AProcess<Tin> process)
        {
            ProcessList.Add(process);
            var currChild = process.Next;
            while (currChild != null)
            {
                ProcessList.Add(currChild);////////////
                currChild = currChild.Next;
            }
        }
        public void Clear() { ProcessList.Clear(); }

        public ProcessResult<Tin> ApplyProcess(Tin tinObj)
        {
            var res = new ProcessResult<Tin>();
            if (ProcessList == null)
            {
                res.IsOk = false;
                res.ErrInfo = "Process list is null";
                return res;
            }

            var currProcess = ProcessList.FirstOrDefault();
            ProcessResult<Tin> currRes = new ProcessResult<Tin>() { ResBwIm = tinObj };

            foreach (var proc in ProcessList.Skip(1)) { }

            while (currProcess != null)
            {
                var procRes = currProcess.Process(currRes.ResBwIm);
                if (procRes.IsOk == false)
                    break;
                currRes = procRes;
                currProcess = currProcess.Next;
            }
            return currRes;
        }


    }
}
