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
        private double xFrom;
        private double yFrom;
        private double xTo;
        private double yTo;

        public double XFrom
        {
            get => xFrom;
            set => SetProperty(ref xFrom, value);
        }

        public double YFrom
        {
            get => yFrom;
            set => SetProperty(ref yFrom, value);
        }

        public double XTo
        {
            get => xTo;
            set => SetProperty(ref xTo, value);
        }

        public double YTo
        {
            get => yTo;
            set => SetProperty(ref yTo, value);
        }


    }
}
