using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlItemsControlDataContextTest.MVVM;

namespace UserControlItemsControlDataContextTest
{
    class MyUserControlVM : ObservableObject
    {
        private string _aStr = GetIsInDesignMode() ? "Test" : string.Empty;
        /// <summary>
        /// A basic string field for display.
        /// </summary>
        public string AStr
        {
            get
            {
                return _aStr;
            }
            set
            {
                SetProperty(nameof(AStr), ref _aStr, value);
            }
        }
    }
}
