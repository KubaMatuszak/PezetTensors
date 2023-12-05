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
        private Cable _cable;
        public CableViewModel(Cable cable)
        {
            _cable = cable;
        }

        public double XFrom
        {
            get => _cable.XFrom;
            set => SetProperty(ref _cable.XFrom, value);
        }

        public double YFrom
        {
            get => _cable.YFrom;
            set => SetProperty(ref _cable.YFrom, value);
        }

        public double XTo
        {
            get => _cable.XTo;
            set => SetProperty(ref _cable.XTo, value);
        }

        public double YTo
        {
            get => _cable.YTo;
            set => SetProperty(ref _cable.YTo, value);
        }


    }
}
