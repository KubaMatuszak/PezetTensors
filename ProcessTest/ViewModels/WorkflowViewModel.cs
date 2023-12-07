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
            NodeVMs.CollectionChanged += NodeVMs_CollectionChanged;
            CableVMs.CollectionChanged += CableVMs_CollectionChanged;
            
            UpdateHandlers();
        }

        public WorkflowViewModel(Workflow workflow)
        {
            NodeVMs = new System.Collections.ObjectModel.ObservableCollection<NodeViewModel>(
                           workflow.Nodes.Select(n => new NodeViewModel(n)
                           ));
            CableVMs = new System.Collections.ObjectModel.ObservableCollection<CableViewModel>(
                           workflow.Cables.Select(c => new CableViewModel(c)));
            NodeVMs.CollectionChanged += NodeVMs_CollectionChanged;
            CableVMs.CollectionChanged += CableVMs_CollectionChanged;
            UpdateHandlers();
        }

        public void UpdateHandlers()
        {
            foreach(var node in NodeVMs)
            {
                node.SelectedHandler += NodeSelected;
            }
        }

        private void NodeSelected(object? sender, EventArgs e)
        {
            if(sender == null)
                return;
            var clickedNode = sender as NodeViewModel;
            if(clickedNode == null)
                return;

            foreach(var nodevm in NodeVMs.Where(nvm => nvm != clickedNode))
            {
                nodevm.IsSelected = false;
            }
        }


        private void NodeVMs_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems == null)
                return;
            foreach(var item in e.NewItems)
            {
                var vm = item as NodeViewModel;
                if (vm == null)
                    continue;
                vm.SelectedHandler += NodeSelected;
            }
        }

        private void CableVMs_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems == null)
                return;
            foreach (var item in e.NewItems)
            {
                var vm = item as CableViewModel;
            }
        }


        private ObservableCollection<NodeViewModel> nodes = new ObservableCollection<NodeViewModel>();
        private ObservableCollection<CableViewModel> cables = new ObservableCollection<CableViewModel>();
        private Workflow workflow { get; set; }
		public ObservableCollection<NodeViewModel> NodeVMs
		{
			get => nodes;
            set
            {
                SetProperty(ref nodes, value);
                NodeVMs.CollectionChanged += NodeVMs_CollectionChanged;
            }
		}

        public ObservableCollection<CableViewModel> CableVMs
        {
            get => cables;
            set
            {
                SetProperty(ref cables, value);
                CableVMs.CollectionChanged += CableVMs_CollectionChanged;
            }
        }
    }
}
