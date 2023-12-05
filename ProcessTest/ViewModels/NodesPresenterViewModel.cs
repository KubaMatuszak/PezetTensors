using ProcessTest.Model;
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
		private ObservableCollection<Node> nodes;

		public ObservableCollection<Node> Nodes
		{
			get { return nodes; }
			set => SetProperty(ref nodes, value);
		}
	}
}
