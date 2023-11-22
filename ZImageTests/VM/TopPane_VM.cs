using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZImageTests.VM.Bases;
using ZImageTests.VM.Basic;
using ZImageTests.VM.Reactive;

namespace ZImageTests.VM
{
    public class TopPane_VM : ObservableObject
    {
        public TopPane_VM() 
        {
            CloseCmd = new RelayCommand(() => UglyMess.ClosePublisher.Publish(""));
            MinimizeCmd = new RelayCommand(() => UglyMess.MinimizePublisher.Publish());
            MaximizeCmd = new RelayCommand(() => UglyMess.MaximizePublisher.Publish());
            UnMaximizeCmd = new RelayCommand(() => UglyMess.UnMaximizePublisher.Publish());
            UglyMess.MinimizePublisher.Subscribe(() => IsMax = false);
            UglyMess.MaximizePublisher.Subscribe(() => IsMax = true);
            UglyMess.UnMaximizePublisher.Subscribe(() => IsMax = false);
        }

        private RelayCommand _minimize;
        public RelayCommand MinimizeCmd { get => _minimize; set => SetProperty(ref _minimize, value); }

        private RelayCommand _close;
        public RelayCommand CloseCmd { get => _close; set => SetProperty(ref _close, value); }

        private RelayCommand _maximize;
        public RelayCommand MaximizeCmd { get => _maximize; set => SetProperty(ref _maximize, value); }

        private RelayCommand _unMaximize;
        public RelayCommand UnMaximizeCmd { get => _unMaximize; set => SetProperty(ref _unMaximize, value); }

        private bool _isMax = true;
        public bool IsMax { get => _isMax; set => SetProperty(ref _isMax, value); }


    }
}
