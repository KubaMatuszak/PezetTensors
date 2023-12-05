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
		private double xOffset;
		private double yOffset;

		public double XOffset
		{
			get => xOffset;
			set => SetProperty(ref xOffset, value);
		}

        public double YOffset
        {
            get => yOffset;
            set => SetProperty(ref yOffset, value);
        }


    }
}
