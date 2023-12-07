using ProcessTest.Model;
using ProcessTest.ViewModels.basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTest.ViewModels
{
    public class CableViewModel : ObservableObject
    {
        private Cable _c;
        public CableViewModel(Cable cable) { _c = cable; }

        public double XFrom { get => _c.XFrom; set => SetProperty(ref _c.XFrom, value); }

        public double YFrom { get => _c.YFrom; set => SetProperty(ref _c.YFrom, value); }

        public double XTo { get => _c.XTo; set => SetProperty(ref _c.XTo, value); }

        public double YTo { get => _c.YTo; set => SetProperty(ref _c.YTo, value); }


    }
}
