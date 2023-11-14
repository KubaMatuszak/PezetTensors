using PZWrapper.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZImageTests.Types.Elementary;
using ZImageTests.VM.Basic;

namespace ZImageTests.VM.Controls
{
    public class Node_VM : ObservableObject
    {
        private ObservableCollection<AParameter_VM> _parametersVMs = new ObservableCollection<AParameter_VM>();
        public ObservableCollection<AParameter_VM> ParametersMVs { get => _parametersVMs; set => SetProperty(ref _parametersVMs, value); }
        private ANode<Matrix2D> _process;
        private bool _isBypassed;
        public Node_VM(ANode<Matrix2D> proc)
        {
            Proc = proc;
            ParametersMVs = new ObservableCollection<AParameter_VM>(ParamFactory.GetParamVMs(proc.Parameters));
        }

        public Node_VM()
        {
            Proc = null;
            ParametersMVs = new ObservableCollection<AParameter_VM>();
        }



        public string ProcName => _process != null ? _process.ProcessName : "<not specified>";// _process?.ProcessName;

        public ANode<Matrix2D> Proc { get => _process; set => SetProperty(ref _process, value); }
        public bool IsBypassed { get => _process.IsBypassed; set =>  SetProperty(ref _process.IsBypassed, value); }
    }
}
