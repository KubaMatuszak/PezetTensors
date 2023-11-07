using PZWrapper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZImageTests.Types.Elementary;

namespace ZImageTests.Process
{
    public class ProcessAggregator
    {
        public List<ABwProcess> ProcessList = new List<ABwProcess>();
        public void Append(ABwProcess process)
        {
            ProcessList.Add(process);
            var currChild = process.Next;
            while (currChild != null)
            {
                ProcessList.Add((ABwProcess)currChild);
                currChild = currChild.Next;
            }
        }
        public void Clear() {  ProcessList.Clear(); }

        public ProcessResult<BWImage> ApplyProcess(BWImage bwImage)
        {
            var res = new ProcessResult<BWImage>();
            if (ProcessList == null)
            {
                res.IsOk = false;
                res.ErrInfo = "Process list is null";
                return res;
            }

            var currProcess = ProcessList.FirstOrDefault();
            ProcessResult<BWImage> currRes = new ProcessResult<BWImage>() { ResBwIm = bwImage };

            foreach(var proc in ProcessList.Skip(1)) { }

            while(currProcess != null)
            {
                var procRes = currProcess.Process(currRes.ResBwIm);
                if (procRes.IsOk == false)
                    break;
                currRes = procRes;
            }
            return currRes;
        }
    }
}
