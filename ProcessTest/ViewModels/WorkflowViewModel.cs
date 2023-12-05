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
    public class WorkflowViewModel : ObservableObject
    {
        public WorkflowViewModel() 
        {

        }


        public WorkflowViewModel(Workflow workflow)
        {
            NodeVMs = new System.Collections.ObjectModel.ObservableCollection<NodeViewModel>(
                           workflow.Nodes.Select(n => new NodeViewModel(n)
                           ));

            CableVMs = new System.Collections.ObjectModel.ObservableCollection<CableViewModel>(
                           workflow.Cables.Select(c => new CableViewModel(c)));
        }


        private ObservableCollection<NodeViewModel> nodes = new ObservableCollection<NodeViewModel>();
        private ObservableCollection<CableViewModel> cables = new ObservableCollection<CableViewModel>();
        private Workflow workflow { get; set; }
		public ObservableCollection<NodeViewModel> NodeVMs
		{
			get => nodes; 
			set => SetProperty(ref nodes, value);
		}

        public ObservableCollection<CableViewModel> CableVMs
        {
            get => cables;
            set => SetProperty(ref cables, value);
        }

    }
}
