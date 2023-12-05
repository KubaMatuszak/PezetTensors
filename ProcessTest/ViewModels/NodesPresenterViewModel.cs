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
		private ObservableCollection<NodeViewModel> nodes = new ObservableCollection<NodeViewModel>();
        private ObservableCollection<CableViewModel> cables = new ObservableCollection<CableViewModel>();

		public ObservableCollection<NodeViewModel> Nodes
		{
			get { return nodes; }
			set => SetProperty(ref nodes, value);
		}

        public ObservableCollection<CableViewModel> Cables
        {
            get { return cables; }
            set => SetProperty(ref cables, value);
        }

    }
}
