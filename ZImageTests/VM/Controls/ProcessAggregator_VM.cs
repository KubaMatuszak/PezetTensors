using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZImageTests.Process.Aggregators;
using ZImageTests.Types.Elementary;

namespace ZImageTests.VM.Controls
{

    public class ProcessAggregator_VM : ObservableObject
    {
		public ProcessAggregator_VM(BWLinearProcessAggregator processAggregator)
		{
			AggregateName = processAggregator.Name;
			foreach(var proc in processAggregator.ProcessList)
			{
				Node_VM process_VM = new Node_VM(proc);
			}
        }

		private ObservableCollection<Node_VM> _processes;
		private string _aggregateName;


		public string AggregateName { get => _aggregateName; set => SetProperty(ref _aggregateName, value); }
		public ObservableCollection<Node_VM> AllProcesses { get { return _processes; } set { SetProperty(ref _processes, value); } }

	}
}
