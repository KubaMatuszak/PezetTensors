using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper.Types
{
    public interface IStrandable
    {
        int NoOfDims { get; }
        int[] Strand { get; }  
    }


}
