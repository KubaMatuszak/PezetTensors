using ProcessTest.Model;
using ProcessTest.ViewModels.basic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTest.ViewModels
{
    public class NodesPresenterViewModel : ObservableObject
    {
		private ObservableCollection<NodeViewModel> nodes;

		public ObservableCollection<NodeViewModel> Nodes
		{
			get { return nodes; }
			set => SetProperty(ref nodes, value);
		}
	}
}
