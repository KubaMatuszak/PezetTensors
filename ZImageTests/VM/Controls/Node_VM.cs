using PZWrapper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZImageTests.Types.Elementary;

namespace ZImageTests.VM.Controls
{
    public class Node_VM : ObservableObject
    {
        private AProcess<Matrix2D> _process;

        public Node_VM(AProcess<Matrix2D> proc)
        {
            Proc = proc;
        }

        public string ProcName => "sample name";// _process?.ProcessName;

        public AProcess<Matrix2D> Proc { get => _process; set => SetProperty(ref _process, value); }
    }
}
