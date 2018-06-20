using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlItemsControlDataContextTest.MVVM;

namespace UserControlItemsControlDataContextTest
{
    class MainWindowVM : ObservableObject
    {
        private readonly BindingList<MyUserControlVM> _items = GetIsInDesignMode()
            ? new BindingList<MyUserControlVM>(new MyUserControlVM[] { new MyUserControlVM() { AStr = "Test 1", }, new MyUserControlVM() { AStr = "Test 2", }, new MyUserControlVM() { AStr = "Test 3", }, })
            : new BindingList<MyUserControlVM>();
        /// <summary>
        /// Items list.
        /// We initialise with some dummy values if we are in design mode.
        /// </summary>
        public BindingList<MyUserControlVM> Items
        {
            get
            {
                return _items;
            }
        }


        private DelegateCommand _addItemCommand;
        /// <summary>
        /// Command to add an item to our Items list.
        /// </summary>
        public DelegateCommand AddItemCommand { get { return _addItemCommand ?? (_addItemCommand = new DelegateCommand(AddItem)); } }

        private void AddItem()
        {
            Items.Add(new MyUserControlVM() { AStr = $"Test {Items.Count + 1}", });
        }

    }
}
