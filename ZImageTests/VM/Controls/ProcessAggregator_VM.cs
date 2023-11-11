using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZImageTests.Types.Elementary;

namespace ZImageTests.VM.Controls
{

    public class ProcessAggregator_VM : ObservableObject
    {

		private ObservableCollection<Process_VM> _processes;
		private string _aggregateName;


		public string AggregateName { get => _aggregateName; set => SetProperty(ref _aggregateName, value); }
		public ObservableCollection<Process_VM> AllProcesses { get { return _processes; } set { SetProperty(ref _processes, value); } }

	}
}
