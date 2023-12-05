using ProcessTest.Model;
using ProcessTest.ViewModels.basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTest.ViewModels
{
    public class NodeViewModel : ObservableObject
    {
        private Node _n;

        public NodeViewModel() { }
        public NodeViewModel(Node n)
        {
            _n = n;
        }

        public double XOffset { get => _n.X; set => SetProperty(ref _n.X, value); }

        public double YOffset { get => _n.Y; set => SetProperty(ref _n.Y, value);}

        public bool IsSelected { get => _n.IsSelected; set => SetProperty(ref _n.IsSelected, value); }

    }
}
