using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZImageTests.VM.Basic;
using ZImageTests.VM.Reactive;

namespace ZImageTests.VM
{
    public class Main_VM : ObservableObject
    {
        public Main_VM() 
        {
            UglyMess.ClosePublisher.Subscribe(() => Application.Current.Shutdown(0));
            UglyMess.MinimizePublisher.Subscribe(() => WindowState = WindowState.Minimized);
            UglyMess.MaximizePublisher.Subscribe(() => WindowState = WindowState.Maximized);
            UglyMess.UnMaximizePublisher.Subscribe(() => WindowState = WindowState.Normal);
        }    
        private TopPane_VM _menuVM = new TopPane_VM();
        public TopPane_VM MainMenu_VM { get { return _menuVM; } set => SetProperty(ref _menuVM, value); }

        private WindowState _windowState = WindowState.Maximized;
        public WindowState WindowState { get => _windowState; set => SetProperty(ref _windowState, value); }

    }




}
