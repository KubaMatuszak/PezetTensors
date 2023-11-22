using System.Collections.ObjectModel;

namespace ZImageTests.VM
{
    public class MainMenu_VM
    {
        public ObservableCollection<MenuItem_VM> MenuItems { get; set; }

        public MainMenu_VM()
        {
            // Initialize MenuItems collection and add menu items
            MenuItems = new ObservableCollection<MenuItem_VM>
        {
            new MenuItem_VM("File", new ObservableCollection<MenuItem_VM>
            {
                new MenuItem_VM("New"),
                new MenuItem_VM("Open"),
                new MenuItem_VM("Save")
            }),
            new MenuItem_VM("Edit", new ObservableCollection<MenuItem_VM>
            {
                new MenuItem_VM("Cut"),
                new MenuItem_VM("Copy"),
                new MenuItem_VM("Paste")
            })
        };
        }
    }


    public class MenuItem_VM
    {
        public string Header { get; set; }
        public ObservableCollection<MenuItem_VM> SubMenuItems { get; set; }

        public MenuItem_VM(string header, ObservableCollection<MenuItem_VM> subMenuItems = null)
        {
            Header = header;
            SubMenuItems = subMenuItems ?? new ObservableCollection<MenuItem_VM>();
        }
    }


}
